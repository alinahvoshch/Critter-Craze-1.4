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
	public class LunaMoth : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 3;
			Main.npcCatchable[NPC.type] = true;
		}

		public override void SetDefaults()
		{
			NPC.width = 24;
			NPC.height = 24;
			NPC.damage = 0;
			NPC.dontCountMe = true;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			
			NPC.catchItem = ModContent.ItemType<LunaMothItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 64;
			NPC.npcSlots = 0;
			NPC.noGravity = true;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<LunaMothBanner>();
			AIType = NPCID.Butterfly;
		}
		
		public override void AI()
		{
			Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .05f, .18f, .2f);
			NPC.spriteDirection = -NPC.direction;
		}
		
		public override void HitEffect(NPC.HitInfo hit)
        {
        	if (NPC.life <= 0)
        	{
        		Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Moth1").Type, 1f);
        		Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Moth3").Type, 1f);
        	}
        }

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.PlayerSafe && !Main.dayTime && spawnInfo.SpawnTileY < Main.rockLayer ? 0.02f : 0f;
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
