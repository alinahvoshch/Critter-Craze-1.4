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
	public class Crismite : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 28;
			NPC.height = 24;
			NPC.damage = 0;
			NPC.dontCountMe = true;
			NPC.defense = 9999;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit5;
			NPC.DeathSound = SoundID.NPCDeath16;

			NPC.catchItem = ModContent.ItemType<CrismiteItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 7;
			NPC.npcSlots = 0;
			NPC.noGravity = false;
			AIType = NPCID.Mouse;
			AnimationType = NPCID.Mouse;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<CrismiteBanner>();
		}

		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Crismite").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Crismite1").Type, 1f);
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
		{
			CrittersUtility.DrawNPCGlowMask(spriteBatch, NPC, ModContent.Request<Texture2D>("Critters/NPCs/Masks/Crismite_Glow").Value, screenPos);
		}

		public int Counter;
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
				Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .15f, .3f, .6f);
		}
		

		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CrismiteCrystal>(), 6));
		}
	}
}
