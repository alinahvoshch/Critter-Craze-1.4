using System;
using Critters.Items.Plants;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Fish
{
    public class SeaweedRoll : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
			Item.height = 30;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 30;
			
			Item.buffType = BuffID.WellFed;
			Item.buffTime = 45000;
            Item.noMelee = true;
            Item.consumable = true;
			Item.UseSound = SoundID.Item2;
            Item.autoReuse = false;

        }
        
		public override bool CanUseItem(Player player)
		{
			player.AddBuff(BuffID.Gills, 1800);
			return true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<RawFish>(), 2)
				.AddIngredient(ModContent.ItemType<Kelp>(), 3)
				.AddTile(TileID.CookingPots)
				.Register();
		}
    }
}
