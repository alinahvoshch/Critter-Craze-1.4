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
	public class BabySlimeRainbow : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 20;
			NPC.height = 16;
			NPC.damage = 0;
			NPC.defense = 1000;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;

			NPC.catchItem = ModContent.ItemType<Items.Consumable.BabySlimeRainbow>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 1;
			NPC.npcSlots = 0;
			NPC.noGravity = false;
			AIType = NPCID.RainbowSlime;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<RainbowBannerItem>();
		}
		
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
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
					
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.RainbowMk2, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					Main.dust[num622].noGravity = true;
					Main.dust[num622].scale = 0.9f;
					Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					
				}
			}
		}
		
		public override void AI()
		{ 
			NPC.spriteDirection = -NPC.direction;
			Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .4f, .4f, .4f);
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
    	{
    		npcLoot.Add(ItemDropRule.Common(ItemID.Gel, 2));
    	}
	}
}
