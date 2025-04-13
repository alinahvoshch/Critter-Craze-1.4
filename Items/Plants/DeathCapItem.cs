using System;
using Critters.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Plants
{
    public class DeathCapItem : ModItem
    {
        public override void SetDefaults()
        {
            
            Item.DefaultToPlaceableTile(ModContent.TileType<DeathCap>());
            Item.width = Item.height = 18;
            Item.value = 6000;

            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
        }
    }
}
