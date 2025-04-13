using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Placeable.Banner;
using Terraria.GameContent.ItemDropRules;

namespace Critters.NPCs.Slime
{
	public class BabySlimeIce : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 2;
		}

		public override void SetDefaults()
		{
			NPC.width = 20;
			NPC.height = 16;
			NPC.damage = 0;
			NPC.defense = 1000;
			NPC.dontCountMe = true;
			NPC.lifeMax = 3;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;

			NPC.catchItem = ModContent.ItemType<Items.Consumable.BabySlimeIce>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 1;
			NPC.npcSlots = 0;
			NPC.noGravity = false;
			AIType = NPCID.IceSlime;
			NPC.alpha = 40;
			AnimationType = NPCID.BlueSlime;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<IceBannerItem>();
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				NPC.position.X += NPC.width / 2;
				NPC.position.Y += NPC.height / 2;
				NPC.width = 20;
				NPC.height = 16;
				NPC.position.X -= NPC.width / 2;
				NPC.position.Y -= NPC.height / 2;
				for (int num621 = 0; num621 < 10; num621++)
				{
					
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.Snow, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].noGravity = true;
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					if (Main.rand.NextBool(2))
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 2));
		}
	}
}
