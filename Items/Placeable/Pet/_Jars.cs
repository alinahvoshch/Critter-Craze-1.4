using System;
using Critters.Items.Moths;
using Critters.Tiles.Pet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Pet
{
	public class GreyMothJar : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 32;
			Item.height = 32;
			Item.value = Item.buyPrice();

			Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Jar_GreyMoth>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<GreyMothItem>())
				.AddIngredient(ItemID.Bottle)
				.Register();
        }
	}
	
	public class LunaMothJar : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 32;
			Item.height = 32;
			

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Jar_LunaMoth>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<LunaMothItem>())
				.AddIngredient(ItemID.Bottle)
				.Register();
		}
	}
	
	public class JewelMothJar : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 32;
			Item.height = 32;
			

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Jar_JewelMoth>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<JewelMothItem>())
				.AddIngredient(ItemID.Bottle)
				.Register();
		}
	}
	
	public class GoldMothJar : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 32;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 10);

			Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Jar_GoldMoth>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<GoldMothItem>())
				.AddIngredient(ItemID.Bottle)
				.Register();
		}
	}
}