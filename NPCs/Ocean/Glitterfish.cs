using Critters.Items.Consumable;
using Critters.Items.Fish;
using Critters.Items.Placeable.Banner;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Ocean
{
	public class Glitterfish : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 26;
			NPC.height = 22;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;

			NPC.catchItem = ModContent.ItemType<CoralfishItem>();
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<CoralfishBanner>();
			NPC.npcSlots = 0;
			AIType = NPCID.Goldfish;
		}
		
		bool txt = false;
		public override bool PreAI()
		{
			if(!txt)
			{
				for (int i = 0; i < 5; ++i)
				{
		             Vector2 dir = Main.player[NPC.target].Center - NPC.Center;
		             dir.Normalize();
		             dir *= 1;
		             int newNPC = NPC.NewNPC(new EntitySource_Parent(Entity),(int)NPC.Center.X + (Main.rand.Next(-20, 20)), (int)NPC.Center.Y + (Main.rand.Next(-20, 20)), ModContent.NPCType<Glitterfish1>(), NPC.whoAmI);
		              Main.npc[newNPC].velocity = dir;
				}
				txt = true;
			}
			return true;
		}
		

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 0.34f;
		}
		
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Glitter").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Glitter1").Type, 1f);
			}
		}

		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
        	npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawFish>(), 1));
        } 
	}
}
