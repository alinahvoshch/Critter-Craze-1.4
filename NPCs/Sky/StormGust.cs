using System;
using System.IO;
using Critters.Items.Consumable;
using Critters.Tiles.Banner;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using StormGustBanner = Critters.Items.Placeable.Banner.StormGustBanner;


namespace Critters.NPCs.Sky
{
    public class StormGust : ModNPC
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
			
		    NPC.catchItem = ModContent.ItemType<StormGustItem>();
		    Banner = NPC.type;
		    BannerItem = ModContent.ItemType<StormGustBanner>();
		    NPC.height = 34;
		    NPC.damage = 0;
		    NPC.npcSlots = 0;
		    NPC.dontCountMe = true;
		    NPC.noGravity = true;
		    NPC.noTileCollide = false;
		    NPC.HitSound = SoundID.NPCHit11;
		    NPC.DeathSound = SoundID.NPCDeath15;
	    }
		
		public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
        	CrittersUtility.DrawNPCGlowMask(spriteBatch, NPC, ModContent.Request<Texture2D>("Critters/NPCs/Masks/StormGust_Glow").Value, Main.screenPosition);
        }
        
        public override void AI()
        {
	        Player player = Main.player[NPC.target];
	        NPC.spriteDirection = -NPC.direction;
	        if (Main.rand.NextFloat() < 0.131579f)
	        {
		        Dust dust;
		        Vector2 position = NPC.Center;
		        dust = Dust.NewDustPerfect(position, DustID.Cloud, new Vector2(0f, 8.421053f), 0, new Color(255,255,255), 1.447368f);
		        dust.noGravity = true;
		        dust.fadeIn = 0.5526316f;
	        }
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
			       int num622 = Dust.NewDust(new Vector2(NPC.position.X, NPC.position.Y), NPC.width, NPC.height, DustID.Scorpion, 0f, 0f, 100, default(Color), 1f);
			       Main.dust[num622].noGravity = true;
			       Main.dust[num622].velocity *= .1f;
		       }
	       }
        }

        public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			return spawnInfo.Player.ZoneRain  && spawnInfo.SpawnTileY > Main.rockLayer  && !spawnInfo.Player.ZoneSnow  ? 0.194f : 0f;
		}
        
		public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<StormGustItem>(), 2));
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