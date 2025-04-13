using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Fish
{
	public class FishCrate : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 1;
		}

		public override void SetDefaults()
		{
			NPC.width = 20;
			NPC.height = 16;
			NPC.damage = 0;
			NPC.defense = 1000;
			NPC.lifeMax = 1;
			NPC.aiStyle = 1;
			NPC.npcSlots = 0;
			Main.npcCatchable[NPC.type] = true;
			NPC.catchItem = ModContent.ItemType<Items.Placeable.FishCrate>();
			NPC.noGravity = false;
			AIType = NPCID.Grasshopper;
			NPC.alpha = 40;
			NPC.dontCountMe = true;
			NPC.dontTakeDamage = true;
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
			if(NPC.wet)
			{
				NPC.aiStyle = 1;
				NPC.npcSlots = 0;
				NPC.noGravity = false;
				AIType = NPCID.Grasshopper;
				NPC.velocity.X *= 0f;
				NPC.velocity.Y *= .9f;
			}
			else
			{
				NPC.aiStyle = 0;
				NPC.npcSlots = 0;
				NPC.noGravity = false;
				AIType = NPCID.BoundGoblin;
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.OceanMonster.Chance * 0.0181f;
		}
	}
}
