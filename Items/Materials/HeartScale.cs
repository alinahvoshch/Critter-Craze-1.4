using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class HeartScale : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 18;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.noMelee = true;
            Item.autoReuse = false;

        }
		public override void AddRecipes()
		{
			Recipe.Create(ItemID.LifeforcePotion)
				.AddIngredient(ItemID.BottledWater)
				.AddIngredient(ModContent.ItemType<HeartScale>(), 9)
				.AddIngredient(ItemID.Waterleaf)
				.AddIngredient(ItemID.Moonglow)
				.AddIngredient(ItemID.Shiverthorn)
				.AddTile(TileID.Bottles)
				.Register();

			Recipe.Create(ItemID.LifeCrystal)
				.AddIngredient(ModContent.ItemType<HeartScale>(), 6)
				.AddTile(TileID.Anvils)
				.Register();
		}
    }
}
