using Critters.Items.Consumable;
using Critters.Items.Materials;
using Critters.Items.Placeable.Banner;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.NPCs.Fish
{
	public class Luvdisc : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 1;
		}

		public override void SetDefaults()
		{
			NPC.width = 30;
			NPC.height = 24;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			NPC.DeathSound = SoundID.NPCDeath1;
			Main.npcCatchable[NPC.type] = true;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<LuvdiscBanner>();
			NPC.catchItem = ModContent.ItemType<LuvdiscItem>();
			
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			NPC.npcSlots = 0;
			NPC.dontCountMe = true;
			AIType = NPCID.Goldfish;
		}
		
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Luvdisc").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("Luvdisc1").Type, 1f);
			}
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HeartScale>(), 2));
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneRockLayerHeight && spawnInfo.Water ? 0.2f : 0f;
		}
	
	}
}
