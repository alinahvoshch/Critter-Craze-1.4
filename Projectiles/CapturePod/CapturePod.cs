using System;
using Critters.Items.Consumable;
using Critters.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles.CapturePod
{
	public class CapturePod : ModProjectile
	{
		public int DamageAdditive;

		public override void SetDefaults()
		{

			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.penetrate = 1;
		}
		
		public override void AI()
		{

			Projectile.rotation = Projectile.velocity.ToRotation() + 1.57f;

			for (int i = 0; i < 10; i++)
			{
				float x = Projectile.Center.X - Projectile.velocity.X * (float)i;
				float y = Projectile.Center.Y - Projectile.velocity.Y * (float)i;
				int num = Dust.NewDust(new Vector2(x, y), 26, 26, DustID.Flare_Blue, 0f, 0f, 0, default(Color), 1f);
				Main.dust[num].alpha = Projectile.alpha;
				Main.dust[num].position.X = x;
				Main.dust[num].position.Y = y;
				Main.dust[num].velocity *= 0f;
				Main.dust[num].noGravity = true;
			}
		}
		// TODO: Redo this with npcloot
		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			Projectile.damage = 1;
			Projectile.knockBack = 0;
			if (target.type == ModContent.NPCType<Lumoth>() && target.life <= 2)
			{
				Projectile.damage = 0;
				Projectile.Kill();
				target.life = 0;
				Item.NewItem(new EntitySource_Parent(Entity), (int)target.position.X, (int)target.position.Y, target.width, target.height, ModContent.ItemType<LumothItem>());
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			SpriteEffects spriteEffects;
			Color color25 = Lighting.GetColor((int)(Projectile.position.X + Projectile.width * 0.5) / 16, (int)((Projectile.position.Y + Projectile.height * 0.5) / 16.0));
			Texture2D texture2D3 = ModContent.Request<Texture2D>(Texture).Value;
			int num156 = texture2D3.Height / Main.projFrames[Projectile.type];
			int y3 = num156 * Projectile.frame;
			Rectangle rectangle = new Rectangle(0, y3, texture2D3.Width, num156);
			Vector2 origin2 = rectangle.Size() / 2f;
			int num157;
			int num158;
			int num159;
			float value3 = 1f;
			float num160 = 0f;
			Main.spriteBatch.Draw(texture2D3, Projectile.position - (7 * Projectile.velocity) + Projectile.Size / 2f - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle?(rectangle), lightColor, Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0f);
			Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Critters/Glowmask/CapturePod").Value, Projectile.position - (7 * Projectile.velocity) + Projectile.Size / 2f - Main.screenPosition + new Vector2(0f, Projectile.gfxOffY), new Rectangle?(rectangle), Color.White, Projectile.rotation, origin2, Projectile.scale, SpriteEffects.None, 0f);
			return false;
		}
	}
}
