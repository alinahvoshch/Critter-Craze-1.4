using Critters.Items.Consumable;
using Critters.Items.Fish;
using Critters.Items.Placeable.Banner;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Ocean
{
	public class Gulper : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 6;
		}

		public override void SetDefaults()
		{
			NPC.width = 24;
			NPC.height = 16;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit1;
			
			NPC.catchItem = ModContent.ItemType<GulperItem>();
			NPC.DeathSound = SoundID.NPCDeath1;
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 16;
			NPC.noGravity = true;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<GulperBanner>();
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
				NPC.position.X += NPC.width / 2;
				NPC.position.Y += NPC.height / 2;
				NPC.width = 30;
				NPC.height = 30;
				NPC.position.X -= NPC.width / 2;
				NPC.position.Y -= NPC.height / 2;
				for (int num621 = 0; num621 < 20; num621++)
				{
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.Flare_Blue, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num622].velocity *= 1f;
					Main.dust[num622].noGravity = true;
					Main.dust[num622].scale = 0.23f;
					Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
		}

		private int Counter;
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
			Counter++;
			if (Counter == 100)
			{
				NPC.velocity.Y *= 10.0f;
				NPC.velocity.X *= 4.0f;
			}
			if (Counter >= 200)
			{
				Counter = 0;
			}
		}
		
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 0.31f;
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawFish>(), 2));
		} 
	}
}
