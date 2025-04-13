using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class GummyWorm : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
			Item.height = 12;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 999;
			Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;
			Item.bait = 30;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }
        
		public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<BabySlimeBlue>(), 1)
                .AddIngredient(ItemID.Worm, 1)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}
