using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Projectiles
{
	public class KelpHookHead : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			Main.projHook[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 16;
			Projectile.aiStyle = 7;
			Projectile.friendly = true;
			Projectile.penetrate = -1;
			Projectile.tileCollide = false;
			Projectile.timeLeft *= 10;

		}

		public override bool PreAI()
		{
			if (Main.player[Projectile.owner].dead || Main.player[Projectile.owner].stoned || Main.player[Projectile.owner].webbed || Main.player[Projectile.owner].frozen)
			{
				Projectile.Kill();
				return false;
			}
			Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
			Vector2 vector = new Vector2(Projectile.position.X + Projectile.width * 0.5f, Projectile.position.Y + Projectile.height * 0.5f);
			float num = mountedCenter.X - vector.X;
			float num2 = mountedCenter.Y - vector.Y;
			float num3 = (float)Math.Sqrt(num * num + num2 * num2);
			Projectile.rotation = (float)Math.Atan2(num2, num) - 1.57f;
			if (Projectile.ai[0] == 0f)
			{
				if (num3 > 300f)
				{
					Projectile.ai[0] = 1f;
				}
				Vector2 value = Projectile.Center - new Vector2(5f);
				Vector2 value2 = Projectile.Center + new Vector2(5f);
				Point point = (value - new Vector2(16f)).ToTileCoordinates();
				Point point2 = (value2 + new Vector2(32f)).ToTileCoordinates();
				int num4 = point.X;
				int num5 = point2.X;
				int num6 = point.Y;
				int num7 = point2.Y;
				if (num4 < 0)
				{
					num4 = 0;
				}
				if (num5 > Main.maxTilesX)
				{
					num5 = Main.maxTilesX;
				}
				if (num6 < 0)
				{
					num6 = 0;
				}
				if (num7 > Main.maxTilesY)
				{
					num7 = Main.maxTilesY;
				}
				for (int i = num4; i < num5; i++)
				{
					int j = num6;
					while (j < num7)
					{
						// logic ???
						if (Main.tile[i, j] == null)
						{
							continue;
						}
						Vector2 vector2;
						vector2.X = i * 16;
						vector2.Y = j * 16;
						if (value.X + 10f > vector2.X && value.X < vector2.X + 16f && value.Y + 10f > vector2.Y && value.Y < vector2.Y + 16f && Main.tile[i, j].HasUnactuatedTile && (Main.tileSolid[Main.tile[i, j].TileType] || Main.tile[i, j].TileType == 314) && (Projectile.type != 403 || Main.tile[i, j].TileType == 314))
						{
							if (Main.player[Projectile.owner].grapCount < 10)
							{
								Main.player[Projectile.owner].grappling[Main.player[Projectile.owner].grapCount] = Projectile.whoAmI;
								Main.player[Projectile.owner].grapCount++;
							}
							if (Main.myPlayer == Projectile.owner)
							{
								int num8 = 0;
								int num9 = -1;
								int num10 = 100000;
								int num11 = 1;
								for (int k = 0; k < 1000; k++)
								{
									if (Main.projectile[k].active && Main.projectile[k].owner == Projectile.owner && Main.projectile[k].type == Projectile.type)
									{
										if (Main.projectile[k].timeLeft < num10)
										{
											num9 = k;
											num10 = Main.projectile[k].timeLeft;
										}
										num8++;
									}
								}
								if (num8 > num11)
								{
									Main.projectile[num9].Kill();
								}
							}
							WorldGen.KillTile(i, j, true, true);
							SoundEngine.PlaySound(SoundID.Item1, new Vector2(i * 16, j * 16));
							Projectile.velocity.X = 0f;
							Projectile.velocity.Y = 0f;
							Projectile.ai[0] = 2f;
							Projectile.position.X = i * 16 + 8 - Projectile.width / 2;
							Projectile.position.Y = j * 16 + 8 - Projectile.height / 2;
							Projectile.damage = 0;
							Projectile.netUpdate = true;
							if (Main.myPlayer == Projectile.owner)
							{
								NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, Projectile.owner);
								break;
							}
							break;
						}
						else
						{
							j++;
						}
					}
					if (Projectile.ai[0] == 2f)
					{
						return false;
					}
				}
				return false;
			}
			if (Projectile.ai[0] == 1f)
			{
				float num12 = 24f;
				if (num3 < 24f)
				{
					Projectile.Kill();
				}
				num3 = num12 / num3;
				num *= num3;
				num2 *= num3;
				Projectile.velocity.X = num;
				Projectile.velocity.Y = num2;
				return false;
			}
			if (Projectile.ai[0] == 2f)
			{
				int num13 = (int)(Projectile.position.X / 16f) - 1;
				int num14 = (int)((Projectile.position.X + Projectile.width) / 16f) + 2;
				int num15 = (int)(Projectile.position.Y / 16f) - 1;
				int num16 = (int)((Projectile.position.Y + Projectile.height) / 16f) + 2;
				if (num13 < 0)
				{
					num13 = 0;
				}
				if (num14 > Main.maxTilesX)
				{
					num14 = Main.maxTilesX;
				}
				if (num15 < 0)
				{
					num15 = 0;
				}
				if (num16 > Main.maxTilesY)
				{
					num16 = Main.maxTilesY;
				}
				bool flag = true;
				for (int l = num13; l < num14; l++)
				{
					for (int m = num15; m < num16; m++)
					{
						if (Main.tile[l, m] == null)
						{
							continue;
						}
						Vector2 vector3;
						vector3.X = l * 16;
						vector3.Y = m * 16;
						if (Projectile.position.X + Projectile.width / 2 > vector3.X && Projectile.position.X + Projectile.width / 2 < vector3.X + 16f && Projectile.position.Y + Projectile.height / 2 > vector3.Y && Projectile.position.Y + Projectile.height / 2 < vector3.Y + 16f && Main.tile[l, m].HasUnactuatedTile && (Main.tileSolid[Main.tile[l, m].TileType] || Main.tile[l, m].TileType == 314 || Main.tile[l, m].TileType == 5))
						{
							flag = false;
						}
					}
				}
				if (flag)
				{
					Projectile.ai[0] = 1f;
					return false;
				}
				if (Main.player[Projectile.owner].grapCount < 1)
				{
					Main.player[Projectile.owner].grappling[Main.player[Projectile.owner].grapCount] = Projectile.whoAmI;
					Main.player[Projectile.owner].grapCount++;
					return false;
				}
			}
			return false;
		}

		public override void PostDraw(Color lightColor)
		{
			Texture2D texture = ModContent.Request<Texture2D>("Critters/Projectiles/KelpHook_Chain").Value;
			Vector2 vector = Projectile.Center;
			Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
			Rectangle? sourceRectangle = null;
			Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
			float num = (float)texture.Height;
			Vector2 vector2 = mountedCenter - vector;
			float rotation = (float)Math.Atan2((double)vector2.Y, (double)vector2.X) - 1.57f;
			bool flag = !(float.IsNaN(vector.X) && float.IsNaN(vector.Y));
			if (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y))
			{
				flag = false;
			}
			while (flag)
			{
				if ((double)vector2.Length() < (double)num + 1.0)
				{
					flag = false;
				}
				else
				{
					Vector2 value = vector2;
					value.Normalize();
					vector += value * num;
					vector2 = mountedCenter - vector;
					Color color = Lighting.GetColor((int)vector.X / 16, (int)((double)vector.Y / 16.0));
					color = Projectile.GetAlpha(color);
					Main.spriteBatch.Draw(texture, vector - Main.screenPosition, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
				}
			}
		}
	}
}
