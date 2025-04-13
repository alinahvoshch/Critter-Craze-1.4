using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Moths;
using Critters.Items.Placeable.Banner;
using Terraria.DataStructures;

namespace Critters.NPCs.Moths
{
	public class JewelMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 3;
			Main.npcCatchable[NPC.type] = true;
		}

		public override void SetDefaults()
		{
			NPC.width = 24;
			NPC.height = 20;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.catchItem = ModContent.ItemType<JewelMothItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 64;
			NPC.npcSlots = 0;
			NPC.noGravity = true;
			
			AIType = NPCID.Butterfly;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<JewelMothBanner>();
		}
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
			int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.PinkTorch);
			Main.dust[dust].noGravity = true;
 		}
		
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Moth6").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Moth4").Type, 1f);
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.PlayerSafe && !Main.dayTime && spawnInfo.SpawnTileY < Main.rockLayer ? 0.00959f : 0f;
		}

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
		}
	}
}
