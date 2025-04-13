using System;
using System.Collections.Generic;
using Critters.Items.Consumable;
using Critters.Tiles.Pet;
using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Placeable.Pet
{
	public class BlossomCage : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Blossom>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BlossmoonItem>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
        }
	}
	
	public class CleftCage : ModItem
	{



		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Cleft>();
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<CleftItem>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	
	public class CrismiteCage : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Crismite>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<CrismiteItem>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	
	public class GreenCage : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile =  ModContent.TileType<Terrarium_Green>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BabySlimeGreen>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	
	public class BlueCage : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Blue>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BabySlimeBlue>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	public class IceCage : ModItem
	{

		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Ice>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BabySlimeIce>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	public class SandCage : ModItem
	{
		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Sand>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BabySlimeSand>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
	
	public class RainbowCage : ModItem
	{
		public override void SetStaticDefaults()
		{
		    Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
		}


		public override void SetDefaults()
		{
            Item.width = 22;
			Item.height = 22;
			Item.value = Item.buyPrice(0, 0, 30, 0);;

            Item.maxStack = Item.CommonMaxStack;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 15;
            Item.useAnimation = 15;
            Item.noUseGraphic = true;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;

			Item.createTile = ModContent.TileType<Terrarium_Rainbow>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BabySlimeRainbow>(), 1)
				.AddIngredient(ItemID.Terrarium, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}