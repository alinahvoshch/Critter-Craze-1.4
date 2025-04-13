using Critters.Buffs.Pets;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.Pets
{
	public class UFOPet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
			Main.projPet[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.ZephyrFish);
			AIType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI()
		{
			Player player = Main.player[Projectile.owner];
			player.zephyrfish = false; // Relic from aiType
			return true;
		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
                
			if (!player.dead && player.HasBuff(ModContent.BuffType<UFOPet_Buff>()))
			{
				Projectile.timeLeft = 2;
			}
		}

	}
}