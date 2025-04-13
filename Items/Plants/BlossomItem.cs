using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using Critters.Items.Consumable;
using Critters.Tiles;


namespace Critters.Items.Plants
{
    public class BlossomItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			CrittersGlowmask.AddGlowMask(Item.type, "Critters/Glowmask/BlossomItem");
		}


        public override void SetDefaults()
        {
	        Item.DefaultToPlaceableTile(ModContent.TileType<Blossom>());
            Item.width = 16;
			Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.UseSound = SoundID.Item1;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 30;
            Item.useAnimation = 30;
            Item.autoReuse = false;
            Item.consumable = true;
        }
        
		public override bool AltFunctionUse(Player player)
		{
			return true;
		}
		
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture = ModContent.Request<Texture2D>("Critters/Items/Consumable/BlossomItem").Value;
			Texture2D glowtexture = ModContent.Request<Texture2D>("Critters/Glowmask/BlossomItem").Value;
			spriteBatch.Draw
			(
				glowtexture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale, 
				SpriteEffects.None, 
				0f
			);
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<BlossmoonItem>())
				.AddIngredient(ItemID.Daybloom)
				.AddIngredient(ItemID.CalmingPotion)
				.AddTile(TileID.HeavyWorkBench)
				.Register();
        }
    }
}
