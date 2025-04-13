using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Critters.NPCs;
using Critters.NPCs.Slime;
using Terraria.DataStructures;

namespace Critters.NPCs
{
	public class GlobalCritterNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		
		public bool alchemical = false;
		public override void ResetEffects(NPC npc)
		{
			alchemical = false;
		}

		public override void UpdateLifeRegen(NPC npc, ref int damage)
		{
			bool drain = false;
			if (alchemical)
			{
				drain = true;
				npc.lifeRegen -= 8;
				damage = 4;
			}
		}

		public override void HitEffect(NPC npc, NPC.HitInfo hit)
		{
			if (Main.netMode != NetmodeID.MultiplayerClient && npc.life <= 0)
			{
				if(npc.netID == NPCID.RainbowSlime)
				{
					Vector2 spawnAt = npc.Center + new Vector2(0f, npc.height / 2f);
					NPC.NewNPC(new EntitySource_SpawnNPC(), (int)spawnAt.X, (int)spawnAt.Y,
						ModContent.NPCType<BabySlimeRainbow>());
				}
				if (Main.rand.NextBool(6))
				{
					if(npc.netID == NPCID.GreenSlime)
					{
						Vector2 spawnAt = npc.Center + new Vector2(0f, npc.height / 2f);
						NPC.NewNPC(new EntitySource_SpawnNPC(), (int)spawnAt.X, (int)spawnAt.Y,
							ModContent.NPCType<BabySlimeGreen>());
					}
					if(npc.netID == NPCID.BlueSlime)
					{
						Vector2 spawnAt = npc.Center + new Vector2(0f, npc.height / 2f);
						NPC.NewNPC(new EntitySource_SpawnNPC(), (int)spawnAt.X, (int)spawnAt.Y,
							ModContent.NPCType<BabySlimeBlue>());
					}
					if(npc.netID == NPCID.IceSlime)
					{
						Vector2 spawnAt = npc.Center + new Vector2(0f, npc.height / 2f);
						NPC.NewNPC(new EntitySource_SpawnNPC(), (int)spawnAt.X, (int)spawnAt.Y,
							ModContent.NPCType<BabySlimeIce>());
					}
					if(npc.netID == NPCID.SandSlime)
					{
						Vector2 spawnAt = npc.Center + new Vector2(0f, npc.height / 2f);
						NPC.NewNPC(new EntitySource_SpawnNPC(), (int)spawnAt.X, (int)spawnAt.Y,
							ModContent.NPCType<BabySlimeSand>());
					}
				}
			}
		}
	}
}