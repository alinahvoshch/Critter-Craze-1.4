using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Critters.Items.Consumable;
using Terraria.DataStructures;

namespace Critters.NPCs.SacTool
{
	public class FlareSnake : ModNPC
	{
		public override void SetStaticDefaults()
		{
			Main.npcCatchable[NPC.type] = true;
			Main.npcFrameCount[NPC.type] = 4;
		}

		public override void SetDefaults()
		{
			NPC.width = 44;
			NPC.dontCountMe = true;
			NPC.height = 30;
			NPC.damage = 0;
			NPC.defense = 0;
			NPC.lifeMax = 5;
			NPC.HitSound = SoundID.NPCHit7;
			NPC.DeathSound = SoundID.NPCDeath4;

			NPC.catchItem = ModContent.ItemType<SnakeItem>();
			NPC.knockBackResist = .45f;
			NPC.aiStyle = 7;
			NPC.npcSlots = 0;
			AIType = NPCID.Scorpion;
			AnimationType = NPCID.Scorpion;
		}
		
		public override void HitEffect(NPC.HitInfo hit)
		{
			if (NPC.life <= 0)
			{
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("SkullBug2").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("SkullBug1").Type, 1f);
				Gore.NewGore(new EntitySource_Parent(Entity), NPC.position, NPC.velocity, Mod.Find<ModGore>("SkullBug1").Type, 1f);
			}
		}
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
	        CrittersUtility.DrawNPCGlowMask(spriteBatch, NPC, ModContent.Request<Texture2D>("Critters/NPCs/Masks/Serpent_Glow").Value, Main.screenPosition);
        }
        
		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			if (spawnInfo.PlayerSafe)
			{
				return 0f;
			}
			return spawnInfo.Player.ZoneUnderworldHeight ? 1.75f : 0f;
		}
		
		public override void AI()
		{
			NPC.spriteDirection = -NPC.direction;
			if(Main.rand.NextBool(2)&& NPC.velocity.X != 0)
			{
				int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Lava);
				Main.dust[dust].noGravity = true;
				Main.dust[dust].velocity *= 0f;
			}
		}
	}
}
