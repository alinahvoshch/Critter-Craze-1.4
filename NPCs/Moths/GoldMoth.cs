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
	public class GoldMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 3;
		}

		public override void SetDefaults()
		{
			NPC.width = 24;
			NPC.height = 20;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.dontCountMe = true;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<GoldMothItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 64;
			NPC.rarity = 3;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<GoldMothBanner>();
			NPC.npcSlots = 0;
			NPC.noGravity = true;
			AIType = NPCID.Butterfly;
			Main.npcFrameCount[NPC.type] = 3;
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
			int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.GoldCoin);
			Main.dust[dust].noGravity = true;
 		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
            {
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Moth7").Type, 1f);
                Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Moth5").Type, 1f);
            }
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.PlayerSafe && !Main.dayTime ? 0.0007666f : 0f;
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
