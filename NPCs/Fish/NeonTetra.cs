using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Fish;
using Terraria.GameContent.ItemDropRules;

namespace Critters.NPCs.Fish
{
	public class NeonTetra : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 42;
			NPC.height = 16;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ItemID.NeonTetra;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 16;
			NPC.dontCountMe = true;
			NPC.noGravity = true;
			NPC.npcSlots = 0;
			AIType = NPCID.Goldfish;
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
				for (int num621 = 0; num621 < 20; num621++)
				{
					int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Flare_Blue);
					Main.dust[dust].noGravity = false;
					Main.dust[dust].velocity *= 0.5f;
				}
			}
		}
		
		public override void AI()
		{
			Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .025f, .5f, .1f);
			NPC.spriteDirection = -NPC.direction;
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawFish>(), 2));
			
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneJungle && spawnInfo.Water ? 0.15f : 0f;
		}
	
	}
}
