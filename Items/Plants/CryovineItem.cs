using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using Critters.Tiles;


namespace Critters.Items.Plants
{
    public class CryovineItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			CrittersGlowmask.AddGlowMask(Item.type, "Critters/Glowmask/CryovineItem");
		}


        public override void SetDefaults()
        {
	        Item.DefaultToPlaceableTile(ModContent.TileType<Cryovine>());
            Item.width = 18;
			Item.height = 36;
            Item.value = 6000;

            Item.maxStack = 99;

            Item.useStyle = ItemUseStyleID.Swing;
			Item.useTime = 10;
            Item.useAnimation = 15;

            Item.useTurn = true;
            Item.autoReuse = true;
            Item.consumable = true;
            

        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
        {
	        Texture2D texture = ModContent.Request<Texture2D>("Critters/Items/Consumable/CryovineItem").Value;
	        Texture2D glowtexture = ModContent.Request<Texture2D>("Critters/Glowmask/CryovineItem").Value;
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
    }
}
