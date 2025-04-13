using System;

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class StormOrb : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
			Item.height = 16;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
			Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.useTime = Item.useAnimation = 20;

            Item.consumable = true;
            Item.autoReuse = true;

        }
		public override bool CanUseItem(Player player)
        {
			return !Main.raining;
		}
		
		
		bool rainText = false;
        public override bool? UseItem(Player player)
        {
			if (!rainText)
			{
				var text = Language.GetTextValue("Critters.Items.StormOrb.Alert");
				Main.NewText(text, 85, 172, 247);
				rainText = true;
			}
			Main.rainTime = 86400;
			Main.maxRaining = 0.1f;
			Main.raining = true;
			Main.raining = true;
			CrittersWorld.Rain = true; 
			return true;
        }
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<SnowGustItem>())
				.AddIngredient(ModContent.ItemType<StormGustItem>())
				.AddTile(TileID.WorkBenches)
				.Register();
		}
	}
}
