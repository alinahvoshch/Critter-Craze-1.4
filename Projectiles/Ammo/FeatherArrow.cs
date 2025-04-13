using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Graphics.Effects;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.Ammo
{
	public class FeatherArrow : ModProjectile
	{

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
			Projectile.damage = 50;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = 1;
			AIType = ProjectileID.Bullet;
		}

		public override void OnKill(int timeLeft)
		{
			for (int I = 0; I < 8; I++)
				Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CrimtaneWeapons, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);

		}
	}
}
