using Critters.Items.Consumable;
using Critters.Items.Fish;
using Critters.Items.Placeable.Banner;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;

namespace Critters.NPCs.Ocean
{
	public class Floater : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcFrameCount[NPC.type] = 40;
			Main.npcCatchable[NPC.type] = true;
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 22;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit25;

			NPC.catchItem = ModContent.ItemType<FloaterItem>();
			NPC.DeathSound = SoundID.NPCDeath28;
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 18;
			NPC.noGravity = true;
			NPC.npcSlots = 0;
			AIType = NPCID.PinkJellyfish;
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<FloaterBanner>();
		}
		
		bool txt = false;
		public override bool PreAI()
		{
			if(!txt)
			{
				for (int i = 0; i < 8; ++i)
				{
		             Vector2 dir = Main.player[NPC.target].Center - NPC.Center;
		             dir.Normalize();
		             dir *= 1;
		             int newNPC = NPC.NewNPC(new EntitySource_Parent(Entity), (int)NPC.Center.X + (Main.rand.Next(-20, 20)), (int)NPC.Center.Y + (Main.rand.Next(-20, 20)), ModContent.NPCType<Floater1>(), NPC.whoAmI);
		             Main.npc[newNPC].velocity = dir;
				}
				txt = true;
				Lighting.AddLight((int)((NPC.position.X + NPC.width / 2) / 16f), (int)((NPC.position.Y + NPC.height / 2) / 16f), .3f, .2f, .3f);
			}
			return true;
		}

		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
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
			if (spawnInfo.PlayerSafe || Main.dayTime)
			{
				return 0f;
			}
			return SpawnCondition.OceanMonster.Chance * 0.173f;
		}
		

		public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
        	CrittersUtility.DrawNPCGlowMask(spriteBatch, NPC, ModContent.Request<Texture2D>("Critters/NPCs/Masks/Floater_Critter_Glow").Value, Main.screenPosition);
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
					int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.PinkTorch, 0f, 0f, 100, default(Color), 2f);
					Main.dust[num622].velocity *= 1f;
					Main.dust[num622].noGravity = true;
					{
						Main.dust[num622].scale = 0.23f;
						Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
					}
				}
			}
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawFish>(), 3));
		} 
	}
}
