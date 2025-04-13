using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Critters.Items.Lumoth;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Furniture
{
	public class Streetlamp : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 18;
			Item.height = 54;
            Item.value = 6000;

            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Tiles.Furniture.Streetlamp>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Brightbulb>(), 1)
				.AddRecipeGroup(RecipeGroupID.IronBar, 6)
				.AddTile(TileID.HeavyWorkBench)
				.Register();
        }
	}
}