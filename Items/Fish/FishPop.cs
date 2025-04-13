using System;
using Critters.Items.Plants;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Fish
{
    public class FishPop : ModItem
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
			Item.buffTime = 110000;
            Item.noMelee = true;
            Item.consumable = true;
			Item.UseSound = SoundID.Item2;
            Item.autoReuse = false;

        }
		public override bool CanUseItem(Player player)
		{
			player.AddBuff(BuffID.Ironskin, 1800);
			return true;
		}
		
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<RawFish>(), 2)
				.AddIngredient(ModContent.ItemType<CryovineItem>(), 1)
				.AddTile(TileID.CookingPots)
				.Register();
		}
    }
}
