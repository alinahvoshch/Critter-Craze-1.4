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
	public class Watcher : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 22;
			NPC.height = 32;
			NPC.damage = 0;
			NPC.dontCountMe = true; 
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<WatcherBanner>();
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<WatcherItem>();
			NPC.knockBackResist = .45f;
			NPC.npcSlots = 0;
			NPC.noGravity = true;
			NPC.noTileCollide = true;
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
	            
            	for (int num621 = 0; num621 < 20; num621++)
            	{
            		int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, 14, 0f, 0f, 100, default(Color), 1f);
            		Main.dust[num622].velocity *= .1f;
            		Main.dust[num622].noGravity = true;
            		
            		if (Main.rand.NextBool(2))
            		{
            			Main.dust[num622].scale = 0.9f;
            			Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
            		}
            	}
	            Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("WatcherEye").Type, 1f);
            
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
		
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
		}

		public override void AI()
		{
			Player target = Main.player[NPC.target];
			int distance = (int)Math.Sqrt((NPC.Center.X - target.Center.X) * (NPC.Center.X - target.Center.X) + (NPC.Center.Y - target.Center.Y) * (NPC.Center.Y - target.Center.Y));
		
			if (distance < 220)
			{
				target.AddBuff(BuffID.Darkness, 120); 

			
			}
			if (distance < 220)
			{
				Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .46f, .316f, .85f);
		
				NPC.aiStyle = 5;
				AIType = NPCID.Moth;
			}
			else if (distance > 220)
			{
				NPC.velocity.X *= .65f;
				NPC.velocity.Y *= .65f;
			}
			
			
		}
	}
}
