using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Consumable;
using Critters.Items.Placeable.Banner;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;

namespace Critters.NPCs.Evil
{
	public class Bloodlurker : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 22;
			NPC.height = 32;
			NPC.damage = 0;
			NPC.dontCountMe = true;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<BloodItem>();
			NPC.knockBackResist = .45f;
			NPC.npcSlots = 0; 
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<BloodBanner>();
			NPC.noGravity = false;
			NPC.noTileCollide = false;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				NPC.position.X += NPC.width / 2;
				NPC.position.Y += NPC.height / 2;
				NPC.width = 32;
				NPC.height = 32;
				NPC.position.X -= NPC.width / 2;
				NPC.position.Y -= NPC.height / 2;
				
				for (int num621 = 0; num621 < 30; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.Blood, 0f, 0f, 100);
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					
					if (Main.rand.NextBool(2))
					{
						Main.dust[num622].scale = 1.2f;
						Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					}
				}
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("BloodEye").Type, 1f);
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.SpawnTileY < Main.rockLayer && spawnInfo.Player.ZoneCrimson && !spawnInfo.PlayerSafe && !spawnInfo.Invasion && !spawnInfo.Sky && !Main.eclipse ? 0.0799999f : 0f;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.Lens, 10));
		}

		public override void AI()
		{
			Player target = Main.player[NPC.target];
			
			int distance = (int)Math.Sqrt((NPC.Center.X - target.Center.X) * (NPC.Center.X - target.Center.X) + (NPC.Center.Y - target.Center.Y) * (NPC.Center.Y - target.Center.Y));
		
			if (distance < 100)
			{
				target.AddBuff(BuffID.Weak, 120); 
				NPC.aiStyle = 41;
				AnimationType = NPCID.BlueSlime;
				NPC.spriteDirection = NPC.direction;
				AIType = NPCID.Herpling;
			}
			else if (distance > 220)
			{
				NPC.aiStyle = 1;
				AIType = NPCID.BlueSlime; 
				AnimationType = NPCID.BlueSlime;
			}
			
			
		}
	}
}
