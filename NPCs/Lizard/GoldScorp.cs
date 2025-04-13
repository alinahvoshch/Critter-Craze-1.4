using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Consumable;
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Lizard
{
	public class GoldScorp : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 32;
			NPC.height = 14;
			NPC.damage = 0;
			NPC.dontCountMe = true;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<GoldScorpion>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 7;
			NPC.npcSlots = 0;
			NPC.noGravity = false;
			AIType = NPCID.ScorpionBlack;
			AnimationType = NPCID.ScorpionBlack;
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				NPC.position.X += NPC.width / 2;
				NPC.position.Y += NPC.height / 2;
				NPC.width = 30;
				NPC.height = 30;
				NPC.position.X -= NPC.width / 2;
				NPC.position.Y -= NPC.height / 2;
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.GoldCoin, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num622].velocity *= 1f;
					Main.dust[num622].noGravity = true; 
					Main.dust[num622].scale = 0.23f;
					Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OverworldDayDesert.Chance * 0.0007666f;
		}
		public override void AI()
		{
			Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .1f, .1f, .1f);
			NPC.spriteDirection = -NPC.direction;
			int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GoldCoin);
			Main.dust[dust].noGravity = true;
			Main.dust[dust].velocity *= 0f;
		}
	}
}
