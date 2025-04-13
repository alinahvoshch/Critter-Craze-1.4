using Critters.Items.Consumable;
using Critters.Items.Placeable.Banner;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;


namespace Critters.NPCs.Sky
{
    public class SandGust : ModNPC
    {
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 8;
		}
        public override void SetDefaults()
        {
            NPC.aiStyle = 64;  
			NPC.lifeMax = 5;	 
            NPC.defense = 0;  
            NPC.width = 20;
			
			NPC.catchItem = ModContent.ItemType<SandGustItem>();
			Banner = NPC.type;
			BannerItem = ModContent.ItemType<SandGustBanner>();
            NPC.height = 34;
			NPC.damage = 0;
			NPC.npcSlots = 0;
			NPC.dontCountMe = true;
            NPC.noGravity = true;
            NPC.noTileCollide = false;
			NPC.HitSound = SoundID.NPCHit11;
			NPC.DeathSound = SoundID.NPCDeath15;
        }

        public override void HitEffect(NPC.HitInfo hit)
        {
	       if (NPC.life <= 0)
	       {
		       NPC.position.X += NPC.width / 2;
		       NPC.position.Y += NPC.height / 2;
		       NPC.width = 32;
		       NPC.height = 32;
		       NPC.position.X -= NPC.width / 2;
		       NPC.position.Y -= NPC.height / 2;
		       for (int num621 = 0; num621 < 20; num621++)
		       {
			       int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.Sand, 0f, 0f, 100, default(Color), 1f);
			       Main.dust[num622].velocity *= .1f;
			       if (Main.rand.NextBool(2))
			       {
				       Main.dust[num622].scale = 0.9f;
				       Main.dust[num622].fadeIn = 1f + Main.rand.Next(10) * 0.23f;
			       }
		       }
	       }
        }
        
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return SpawnCondition.SandstormEvent.Chance * 0.18f;
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
		}
		
		public override void ModifyNPCLoot(NPCLoot npcLoot)
		{
			npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SandGustItem>(), 2));
		}
		
		public override void FindFrame(int frameHeight)
		{
			NPC.frameCounter++;
			if (NPC.frameCounter < 32)
			{
				if (NPC.frameCounter % 4 == 0)
				{
					NPC.frame.Y = (int)(NPC.frameCounter / 4) * frameHeight;
				}
			}
			else
			{
				NPC.frameCounter = 0;
			}
		}
    }
}