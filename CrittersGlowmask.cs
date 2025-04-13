using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters
{
    public class CrittersGlowmask : ModPlayer
    {
        private static readonly Dictionary<int, Texture2D> ItemGlowMask = new();

        public static void AddGlowMask(int itemType, string texturePath)
        {
            ItemGlowMask[itemType] = ModContent.Request<Texture2D>(texturePath).Value;
        }

        public static bool TryGetGlowMask(int type, out Texture2D texture)
        {
            return ItemGlowMask.TryGetValue(type, out texture);
        }

        public override void Unload()
        {
            ItemGlowMask.Clear();
        }
    }
    public class GlowMaskHeadLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Head);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => true;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            if (CrittersGlowmask.TryGetGlowMask(player.armor[10].IsAir ? player.armor[0].type : player.armor[10].type, out var texture))
            {
                CrittersUtility.DrawArmorGlowMask(EquipType.Head, texture, drawInfo);
            }
        }
    }
    public class GlowMaskBodyLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.Torso);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => true;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            if (CrittersGlowmask.TryGetGlowMask(player.armor[11].IsAir ? player.armor[1].type : player.armor[11].type, out var texture))
            {
                CrittersUtility.DrawArmorGlowMask(EquipType.Body, texture, drawInfo);
            }
        }
    }
    public class GlowMaskLegsLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new BeforeParent(PlayerDrawLayers.Shoes);

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            if (CrittersGlowmask.TryGetGlowMask(player.armor[12].IsAir ? player.armor[2].type : player.armor[12].type, out var texture))
            {
                CrittersUtility.DrawArmorGlowMask(EquipType.Legs, texture, drawInfo);
            }
        }
    }
    public class GlowMaskHeldItemLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.HeldItem);

        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo) => true;

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            if (player.HeldItem.type >= ItemID.Count && CrittersGlowmask.TryGetGlowMask(player.HeldItem.type, out var texture))
            {
                CrittersUtility.DrawItemGlowMask(texture, drawInfo);
            }
        }
    }
}