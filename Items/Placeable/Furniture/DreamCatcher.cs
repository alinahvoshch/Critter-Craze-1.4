using Terraria;
using System;
using Terraria.ID;
using System.Diagnostics;
using Critters.Items.Materials;
using Critters.Tiles.Catchers;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Furniture
{
	public class DreamCatcher : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 22;
			Item.value = Item.buyPrice(0, 0, 5, 0);
			Item.height = 36;
            Item.value = 6000;

            Item.maxStack = 99;
			Item.rare = ItemRarityID.LightRed;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

            Item.createTile = ModContent.TileType<DreamCatcher_Tile>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<CrimsonFeather>(), 3)
				.AddIngredient(ItemID.Feather, 5)
				.AddIngredient(ItemID.Ruby)
				.AddIngredient(ItemID.SoulofLight)
				.AddRecipeGroup(RecipeGroupID.Wood, 20)
				.AddTile(TileID.WorkBenches)
				.Register();
        }
	}
}