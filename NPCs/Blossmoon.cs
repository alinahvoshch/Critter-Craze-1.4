using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Consumable;

namespace Critters.NPCs
{
	public class Blossmoon : ModNPC
	{
		public override void SetStaticDefaults()
		{			
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 45;
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 20;
			NPC.damage = 0;
			NPC.dontCountMe = true;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;

			NPC.catchItem = ModContent.ItemType<BlossmoonItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 0;
			NPC.npcSlots = 0;
			NPC.noGravity = false;

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
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.DungeonWater, 0f, 0f, 100, default(Color), 1f);
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
			return spawnInfo.SpawnTileY < Main.rockLayer && !Main.dayTime && !spawnInfo.PlayerSafe && !spawnInfo.Invasion && !spawnInfo.Sky && !Main.eclipse ? 0.0509f : 0f;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
		}

		public override bool PreAI()
		{
			Player player = Main.player[NPC.target];
			
			Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .92f, .632f, 1.71f);
			{
				int distance = (int)Math.Sqrt((NPC.Center.X - player.Center.X) * (NPC.Center.X - player.Center.X) + (NPC.Center.Y - player.Center.Y) * (NPC.Center.Y - player.Center.Y));
				if (distance < 480)
				{
						player.AddBuff(BuffID.Calm, 300); 
				}
			}
			
			return true;
		}
	}
}
