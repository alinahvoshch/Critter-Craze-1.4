using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Critters.Projectiles.Summon;
using Terraria.Audio;

namespace Critters.Projectiles.Summon
{
	public class IgnomeSummon : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 8;
			ProjectileID.Sets.MinionSacrificable[Projectile.type] = true;
			ProjectileID.Sets.MinionTargettingFeature[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Raven);
			Projectile.width = 40;
			Projectile.height = 20;
			Projectile.minion = true;
			Projectile.friendly = true;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.netImportant = true;
			AIType = ProjectileID.Raven;
			Projectile.alpha = 0;
			Projectile.penetrate = 2;
			Projectile.minionSlots = 0;
			Projectile.timeLeft = 300;
		}
		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (Projectile.penetrate == 0)
				Projectile.Kill();

			return false;
		}
		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D texture2D = ModContent.Request<Texture2D>(Texture).Value;
			Vector2 origin = new Vector2(texture2D.Width * 0.5f, texture2D.Height / Main.projFrames[Projectile.type] * 0.5f);
			SpriteEffects effects = (Projectile.direction == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
			Vector2 value = new Vector2(Projectile.Center.X - 4f, Projectile.Center.Y - 8f);
			Main.spriteBatch.Draw(texture2D, value - Main.screenPosition, new Rectangle?(Utils.Frame(texture2D, 1, Main.projFrames[Projectile.type], 0, Projectile.frame)), lightColor, Projectile.rotation, origin, Projectile.scale, effects, 0f);
			return false;
		}
		
		public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }
		
		public override bool PreAI()
		{
			Vector2 position = Projectile.Center + Vector2.Normalize(Projectile.velocity) * 8;

			Dust newDust = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height + 20, 6, 0f, 0f, 0, default(Color), 1f)];
			newDust.position = position;
			newDust.velocity = Projectile.velocity.RotatedBy(Math.PI / 2.4f, default(Vector2)) * 0.23F + Projectile.velocity / 2;
			newDust.position += Projectile.velocity.RotatedBy(Math.PI / 2.4f, default(Vector2));
			newDust.fadeIn = 0.5f;
			newDust.noGravity = true;
			newDust = Main.dust[Dust.NewDust(Projectile.position, Projectile.width, Projectile.height + 10, 6, 0f, 0f, 0, default(Color), 1)];
			newDust.position = position;
			newDust.velocity = Projectile.velocity.RotatedBy(-Math.PI / 2.4f, default(Vector2)) * 0.23F + Projectile.velocity / 2;
			newDust.position += Projectile.velocity.RotatedBy(-Math.PI / 2.4f, default(Vector2));
			newDust.fadeIn = 0.5F;
			newDust.noGravity = true;

			for (int i = 0; i < 1; i++)
			{
				newDust = Main.dust[Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6, 0f, 0f, 0, default(Color), 1f)];
				newDust.velocity *= 0.5F;
				newDust.scale *= 1.3F;
				newDust.fadeIn = 1F;
				newDust.noGravity = true;
			}


			return true;
		}
		
		public override bool MinionContactDamage()
		{
			return true;
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			target.AddBuff(BuffID.OnFire, 180, true);
		}

		public override void OnKill(int timeLeft)
		{
				Projectile.NewProjectile(new EntitySource_Parent(Entity),Projectile.Center.X, Projectile.Center.Y, Main.rand.Next(0) / 100,
					Main.rand.Next(0, 0), ModContent.ProjectileType<Explosion>(), Projectile.damage + 10, 0f,
					Projectile.owner);
			Projectile.position.X += Projectile.width / 2;
			Projectile.position.Y += Projectile.height / 2;
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.position.X -= Projectile.width / 2;
			Projectile.position.Y -= Projectile.height / 2;
			for (int i = 0; i < 20; i++)
			{
				int num = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[num].velocity *= 3f;
				Main.dust[num].noGravity = true;
				if (Main.rand.NextBool(2))
				{
					Main.dust[num].scale = 0.5f;
					Main.dust[num].fadeIn = 1f + Main.rand.Next(10) * 0.1f;
				}
			}
			for (int k = 0; k < 3; k++)
			{
				float scaleFactor = 0.33f;
				if (k == 1)
				{
					scaleFactor = 0.66f;
				}
				else if (k == 2)
				{
					scaleFactor = 1f;
				}
				int num3 = Gore.NewGore(new EntitySource_Parent(Entity), new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_417_cp_0 = Main.gore[num3];
				expr_417_cp_0.velocity.X += 1f;
				Gore expr_435_cp_0 = Main.gore[num3];
				expr_435_cp_0.velocity.Y += 1f;
				num3 = Gore.NewGore(new EntitySource_Parent(Entity), new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_4E0_cp_0 = Main.gore[num3];
				expr_4E0_cp_0.velocity.X -= 1f;
				Gore expr_4FE_cp_0 = Main.gore[num3];
				expr_4FE_cp_0.velocity.Y += 1f;
				num3 = Gore.NewGore(new EntitySource_Parent(Entity), new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_5A9_cp_0 = Main.gore[num3];
				expr_5A9_cp_0.velocity.X += 1f;
				Gore expr_5C7_cp_0 = Main.gore[num3];
				expr_5C7_cp_0.velocity.Y -= 1f;
				num3 = Gore.NewGore(new EntitySource_Parent(Entity), new Vector2(Projectile.position.X + Projectile.width / 2 - 24f, Projectile.position.Y + Projectile.height / 2 - 24f), default(Vector2), Main.rand.Next(61, 64), 1f);
				Main.gore[num3].velocity *= scaleFactor;
				Gore expr_672_cp_0 = Main.gore[num3];
				expr_672_cp_0.velocity.X -= 1f;
				Gore expr_690_cp_0 = Main.gore[num3];
				expr_690_cp_0.velocity.Y -= 1f;
			}
			Projectile.position.X += Projectile.width / 2;
			Projectile.position.Y += Projectile.height / 2;
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.position.X -= Projectile.width / 2;
			Projectile.position.Y -= Projectile.height / 2;
			SoundEngine.PlaySound(SoundID.Item14, new Vector2((int)Projectile.position.X, (int)Projectile.position.Y));
			for (int l = 0; l < 40; l++)
			{
				int num4 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, -2f, 0, default(Color), 2f);
				Main.dust[num4].noGravity = true;
				Dust expr_824_cp_0 = Main.dust[num4];
				expr_824_cp_0.position.X += (Main.rand.Next(-50, 51) * 0.05f - 1.5f);
				Dust expr_858_cp_0 = Main.dust[num4];
				expr_858_cp_0.position.Y += (Main.rand.Next(-50, 51) * 0.05f - 1.5f);
				if (Main.dust[num4].position != Projectile.Center)
				{
					Main.dust[num4].velocity = Projectile.DirectionTo(Main.dust[num4].position) * 6f;
				}
			}
		}
	}

}