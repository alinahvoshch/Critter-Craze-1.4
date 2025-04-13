using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using Critters.NPCs;
using Critters.NPCs.Ocean;
using Terraria.DataStructures;

namespace Critters.Items.Consumable
{
    public class CrismiteItem : ModItem
    {
		public override void SetStaticDefaults()
		{
			CrittersGlowmask.AddGlowMask(Item.type, "Critters/Glowmask/CrismiteItem");
		}


        public override void SetDefaults()
        {
            Item.width = 40;
			Item.height = 20;
            Item.rare = ItemRarityID.LightRed;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.useTime = Item.useAnimation = 20;
			Item.bait = 35;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }
		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			Texture2D texture = ModContent.Request<Texture2D>("Critters/Items/Consumable/CrismiteItem").Value;
			Texture2D glowtexture = ModContent.Request<Texture2D>("Critters/Glowmask/CrismiteItem").Value;
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

		public override bool? UseItem(Player player)
		{
			NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Crismite>());
			return true;
		}

	}
}
