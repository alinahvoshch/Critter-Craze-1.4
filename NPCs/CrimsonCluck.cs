using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Critters.Items.Consumable;
using Critters.Items.Materials;
using Critters.Items.Placeable.Banner;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;

namespace Critters.NPCs
{
	public class CrimsonCluck : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 5;
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 30;
			NPC.damage = 0;
			NPC.dontCountMe = true;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath4;

			NPC.catchItem = ModContent.ItemType<CluckItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 24;
			NPC.npcSlots = 0;
			NPC.noGravity = true;
			AIType = NPCID.Bird;
			AnimationType = NPCID.Bird;
						Banner = NPC.type;
			BannerItem = ModContent.ItemType<CrimsonCluckBanner>();
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Cluck1").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Cluck2").Type, 1f);
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.SpawnTileY < Main.rockLayer && spawnInfo.Player.ZoneJungle ? 0.07f : 0f;
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
		}

		public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrimsonFeather>(), 2));
        }
	}
}
