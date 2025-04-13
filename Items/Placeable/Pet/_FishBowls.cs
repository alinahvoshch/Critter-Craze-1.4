using System;
using Critters.Items.Consumable;
using Critters.Tiles.Pet;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Placeable.Pet
{
	public class LuvdiscBowl : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 28;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 0, 30);

			Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Aquarium_Luvdisc>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<LuvdiscItem>())
				.AddIngredient(ItemID.BottledWater)
				.AddTile(TileID.WorkBenches)
				.Register();
        }
	}
	
	public class KelpfishBowl : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 28;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 0, 30);

			Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Aquarium_Kelpfish>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<KelpfishItem>())
				.AddIngredient(ItemID.BottledWater)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	public class LanternfishBowl : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 28;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 0, 30);

			Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Aquarium_Lanternfish>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<LanternfishItem>())
				.AddIngredient(ItemID.BottledWater)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	public class GulperBowl : ModItem
	{ 
		public override void SetDefaults()
		{
            Item.width = 28;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 0, 30);

			Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Aquarium_Gulper>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<GulperItem>())
				.AddIngredient(ItemID.BottledWater)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	public class CoralfishBowl : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 28;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 0, 30);

			Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Aquarium_Coralfish>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<CoralfishItem>())
				.AddIngredient(ItemID.BottledWater)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	public class FloaterBowl : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 28;
			Item.height = 32;
			Item.value = Item.buyPrice(0, 0, 30);

			Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Aquarium_Floater>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<FloaterItem>())
				.AddIngredient(ItemID.BottledWater)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}