using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Fish
{
    public class RawFish : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 22;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 30;
			
			Item.buffType = BuffID.WellFed;
			Item.buffTime = 18000;
            Item.noMelee = true;
            Item.consumable = true;
			Item.UseSound = SoundID.Item2;
            Item.autoReuse = false;

        }
        
		public override bool CanUseItem(Player player)
		{
			player.AddBuff(BuffID.Poisoned, 2700);
			return true;
		}
		
		public override void AddRecipes()
		{
			Recipe.Create(ItemID.CookedFish)
				.AddIngredient(ModContent.ItemType<RawFish>())
				.AddTile(TileID.CookingPots)
				.Register();
			Recipe.Create(ItemID.Sashimi)
				.AddIngredient(ModContent.ItemType<RawFish>())
				.AddTile(TileID.WorkBenches)
				.Register();
		}
    }
}
