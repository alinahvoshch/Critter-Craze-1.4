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
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Lizard
{
	public class Lizard : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 22;
			NPC.height = 24;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath4;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<LizardItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 7;
			NPC.npcSlots = 0;
			NPC.noGravity = false;
			AIType = NPCID.ScorpionBlack;
			AnimationType = NPCID.ScorpionBlack;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<LizardBanner>();
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Lizard").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Lizard1").Type, 1f);
			}
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OverworldDayDesert.Chance * 0.2f;
		}

	}
}
