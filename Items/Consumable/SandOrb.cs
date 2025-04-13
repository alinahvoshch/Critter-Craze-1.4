using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Events;
using Terraria.Localization;

namespace Critters.Items.Consumable
{
    public class SandOrb : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
			Item.height = 16;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.HoldUp;
			Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.useTime = Item.useAnimation = 20;

            Item.consumable = true;
            Item.autoReuse = true;

        }
        
		public override bool CanUseItem(Player player)
        {
			if (Sandstorm.Happening)
			{
				return false;
			}
			return true;
		}
		
		bool sandText = false;
		
        public override bool? UseItem(Player player)
        {
			if (!sandText)
			{
				var text = Language.GetTextValue("Critters.Items.SandOrb.Alert");
				Main.NewText(text, 204, 153, 51);
				sandText = true;
			}
			
			Sandstorm.Happening = true;
			Sandstorm.TimeLeft = 21600;
			Sandstorm.Severity  = 1f;
			CrittersWorld.sandStorm = true; 
			return true;
        }
		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ModContent.ItemType<SandGustItem>())
				.AddIngredient(ModContent.ItemType<GustItem>())
				.AddTile(TileID.WorkBenches)
				.Register();
			
        }
	}
}
