using Critters.Items.Consumable;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Critters.NPCs.Ocean
{
	public class Floater1 : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 40;
		}

		public override void SetDefaults()
		{
			NPC.width = 18;
			NPC.height = 22;
			NPC.damage = 0;
			
			NPC.catchItem = ModContent.ItemType<FloaterItem>();
			NPC.defense = 0;
			NPC.dontCountMe = true;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit25;
			NPC.DeathSound = SoundID.NPCDeath28;
			NPC.knockBackResist = .35f;
			NPC.aiStyle = 18;
			NPC.noGravity = true;
			NPC.npcSlots = 0;
			AIType = NPCID.PinkJellyfish;
		}		

		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter += 0.15f;
			NPC.frameCounter %= Main.npcFrameCount[NPC.type];
			int frame = (int)NPC.frameCounter;
			NPC.frame.Y = frame * frameHeight;
		}
		
		public override bool PreAI()
		{
			Lighting.AddLight((int)((NPC.position.X + (float)(NPC.width / 2)) / 16f), (int)((NPC.position.Y + (float)(NPC.height / 2)) / 16f), .3f, .2f, .3f);
			return true;
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
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
	}
}
