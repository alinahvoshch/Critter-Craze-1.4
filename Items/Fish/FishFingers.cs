using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Fish
{
    public class FishFingers : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 24;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 30;
			
			Item.buffType = BuffID.WellFed;
			Item.buffTime = 72000;
            Item.noMelee = true;
            Item.consumable = true;
			Item.UseSound = SoundID.Item2;
            Item.autoReuse = false;

        }
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<RawFish>(), 3)
				.AddTile(TileID.CookingPots)
				.Register();
		}
    }
}
