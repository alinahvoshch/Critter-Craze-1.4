using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Critters
{
    public static class CrittersUtility
    {
        public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture, Vector2 screenPos)
        {
            SpriteEffects effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Vector2 origin = npc.frame.Size() * 0.5f;
            Vector2 position = npc.Center - screenPos + new Vector2(0, npc.gfxOffY);

            spriteBatch.Draw(
                texture,
                position,
                npc.frame,
                Color.White,
                npc.rotation,
                origin,
                npc.scale,
                effects,
                0f
            );
        }

        public static void DrawArmorGlowMask(EquipType type, Texture2D texture, PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            if (player.invis)
                return;

            Vector2 position = drawInfo.Position;
            Vector2 origin;
            Rectangle frame;
            Color glowColor;
            float rotation;
            Vector2 offset;

            switch (type)
            {
                case EquipType.Head:
                    frame = player.headFrame;
                    origin = frame.Size() * 0.5f;
                    glowColor = drawInfo.headGlowColor;
                    rotation = player.headRotation;
                    offset = new Vector2(
                        player.width / 2f - frame.Width / 2f,
                        player.height - frame.Height + 4f
                    );
                    break;

                case EquipType.Body:
                    frame = player.bodyFrame;
                    origin = frame.Size() * 0.5f;
                    glowColor = drawInfo.bodyGlowColor;
                    rotation = player.bodyRotation;
                    offset = new Vector2(
                        player.width / 2f - frame.Width / 2f,
                        player.height - frame.Height + 4f
                    );
                    break;

                case EquipType.Legs:
                    frame = player.legFrame;
                    origin = frame.Size() * 0.5f;
                    glowColor = drawInfo.legsGlowColor;
                    rotation = player.legRotation;
                    offset = new Vector2(
                        player.width / 2f - frame.Width / 2f,
                        player.height - frame.Height + 4f
                    );
                    break;

                default:
                    return;
            }

            drawInfo.DrawDataCache.Add(new DrawData(
                texture,
                position + offset - Main.screenPosition,
                frame,
                glowColor,
                rotation,
                origin,
                1f,
                drawInfo.playerEffect,
                0
            ));
        }

        public static void DrawItemGlowMask(Texture2D texture, PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            Item item = player.HeldItem;

            if (item.IsAir || player.frozen || drawInfo.shadow != 0f)
                return;

            Vector2 origin = texture.Size() * 0.5f;
            float rotation = player.itemRotation;
            SpriteEffects effect = player.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Vector2 offset = Vector2.Zero;

            if (Item.staff[item.type])
            {
                rotation += player.direction == 1 ? 0.785f : -0.785f;
                offset = new Vector2(item.width * 0.5f, -item.height * 0.5f);
            }

            drawInfo.DrawDataCache.Add(new DrawData(
                texture,
                drawInfo.ItemLocation - Main.screenPosition + offset,
                null,
                Color.White,
                rotation,
                origin,
                item.scale,
                effect,
                0
            ));
        }
        public static Vector2 SafeDirectionTo(this Entity entity, Vector2 destination, Vector2? fallback = null)
        {

            if (!fallback.HasValue)
                fallback = Vector2.Zero;

            return (destination - entity.Center).SafeNormalize(fallback.Value);
        }
        
        public static void DrawHook(this Projectile projectile, Texture2D hookTexture, float angleAdditive = 0f)
        {
            Player player = Main.player[projectile.owner];
            Vector2 center = projectile.Center;
            float angleToMountedCenter = projectile.AngleTo(player.MountedCenter) - MathHelper.PiOver2;
            bool canShowHook = true;
            while (canShowHook)
            {
                float distanceMagnitude = (player.MountedCenter - center).Length(); //Exact same as using a Sqrt
                if (distanceMagnitude < hookTexture.Height + 1f)
                {
                    canShowHook = false;
                }
                else if (float.IsNaN(distanceMagnitude))
                {
                    canShowHook = false;
                }
                else
                {
                    center += projectile.SafeDirectionTo(player.MountedCenter) * hookTexture.Height;
                    Color tileAtCenterColor = Lighting.GetColor((int)center.X / 16, (int)(center.Y / 16f));
                    Main.spriteBatch.Draw(hookTexture, center - Main.screenPosition,
                        new Rectangle?(new Rectangle(0, 0, hookTexture.Width, hookTexture.Height)),
                        tileAtCenterColor, angleToMountedCenter + angleAdditive,
                        hookTexture.Size() / 2, 1f, SpriteEffects.None, 0f);
                }
            }
        }
    }
}