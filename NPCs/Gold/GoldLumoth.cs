using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Lumoth;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Gold
{
	public class GoldLumoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 32;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit4;
			NPC.DeathSound = SoundID.NPCDeath4;
			NPC.dontCountMe = true;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<Items.Consumable.GoldLumoth>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 64;
			NPC.npcSlots = 0;
			NPC.noGravity = true;
			AIType = NPCID.Firefly;
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			CrittersUtility.DrawNPCGlowMask(spriteBatch, NPC, ModContent.Request<Texture2D>("Critters/NPCs/Masks/GoldLumoth_Glow").Value, Main.screenPosition);
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				NPC.position.X += NPC.width / 2;
				NPC.position.Y += NPC.height / 2;
				NPC.width = NPC.height = 32;
				NPC.position.X -= NPC.width / 2;
				NPC.position.Y -= NPC.height / 2;
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.GoldCoin, 0f, 0f, 100, default(Color), 1f);
					Main.dust[num622].velocity *= .1f;
					if (Main.rand.NextBool(2))
					{
						Main.dust[num622].scale = 0.9f;
						Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe)
			{
				return 0f;
			}
			return SpawnCondition.Cavern.Chance * 0.000763f;
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
			NPC.spriteDirection = -NPC.direction;
			int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GoldCoin);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
			Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .4f, .4f, .4f);
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Brightbulb>(), 3));
		} 
	}
}
