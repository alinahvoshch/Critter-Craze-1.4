using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Lumoth
{
	[AutoloadEquip(EquipType.Balloon)]
    public class LumothLantern : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 38;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
	        Lighting.AddLight(player.position, 1.25f, .9f, .6f);
        }

        public override void UpdateVanity(Player player)
        {
	        Lighting.AddLight(player.position, .55f, .05f, .08f);
        }

        public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Brightbulb>(), 1)
				.AddIngredient(ItemID.SilverBar, 5)
				.AddIngredient(ItemID.Wood, 20)
				.AddTile(TileID.WorkBenches)
				.Register();
			
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<Brightbulb>(), 1)
				.AddIngredient(ItemID.TungstenBar, 5)
				.AddIngredient(ItemID.Wood, 20)
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}
