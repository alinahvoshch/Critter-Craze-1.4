using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.Magic
{
	public class CrystalProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.penetrate = 4;
			Projectile.alpha = 255;
			Projectile.timeLeft =  540;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
				Projectile.Kill();
			else
			{
				Projectile.ai[0] += 0.1f;
				if (Projectile.velocity.X != oldVelocity.X)
					Projectile.velocity.X = -oldVelocity.X;

				if (Projectile.velocity.Y != oldVelocity.Y)
					Projectile.velocity.Y = -oldVelocity.Y;

				Projectile.velocity *= 0.75f;
			}
			return false;
		}
		public override bool PreAI()
		{
			for (int i = 0; i < 8; i++)
			{
				float x = Projectile.Center.X - Projectile.velocity.X / 9f * i;
				float y = Projectile.Center.Y - Projectile.velocity.Y / 9f * i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, DustID.Flare_Blue);
				Main.dust[num].alpha = Projectile.alpha;
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}


			return true;
		}

		public override void OnKill(int timeLeft)
		{
			int n = Main.rand.Next(2, 5);
			int deviation = Main.rand.Next(0, 300);
			for (int i = 0; i < n; i++)
			{
				float rotation = MathHelper.ToRadians(270 / n * i + deviation);
				Vector2 perturbedSpeed = new Vector2(Projectile.velocity.X, Projectile.velocity.Y).RotatedBy(rotation);
				perturbedSpeed.Normalize();
				perturbedSpeed.X *= 5.5f;
				perturbedSpeed.Y *= 5.5f;
				// TODO: Projectile where?
				// Projectile.NewProjectile(Projectile.Center.X, Projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<CrystalBolt>(), Projectile.damage / 3 * 2, Projectile.knockBack, Projectile.owner);
			}

			SoundEngine.PlaySound(SoundID.Item27, new Vector2( (int)Projectile.position.X, (int)Projectile.position.Y));
		}
	}
}
