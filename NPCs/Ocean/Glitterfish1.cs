using Critters.Items.Consumable;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.NPCs.Ocean
{
	public class Glitterfish1 : ModNPC
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
			NPC.dontCountMe = true;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			
			NPC.catchItem = ModContent.ItemType<CoralfishItem>();
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			NPC.npcSlots = 0;
			AIType = NPCID.Goldfish;
		}
		
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
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
	
	}
}
