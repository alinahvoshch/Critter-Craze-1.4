using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles
{
	internal class Explosion : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 1;
			Projectile.timeLeft = 20;
			Projectile.height = 100;
			Projectile.width = 100;
			Projectile.alpha = 255;
			AIType = 14;
			Projectile.extraUpdates = 1;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 180, true);
		}
	}
}
