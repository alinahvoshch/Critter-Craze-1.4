using System;
using Critters.Buffs;
using Critters.Items.Plants;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Potions
{
    public class ApparationBrew : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20; 
            Item.height = 30;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 30;

            Item.useStyle = ItemUseStyleID.EatFood;
            Item.useTime = Item.useAnimation = 20;

            Item.consumable = true;
            Item.autoReuse = false;

            Item.buffType = ModContent.BuffType<Apparition_Buff>();
            Item.buffTime = 360;

            Item.UseSound = SoundID.Item3;
        }
        
		public override bool CanUseItem(Player player)
		{
			player.AddBuff(BuffID.Cursed, 420);
			return true;
		}
        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<GhostReedItem>())
                .AddIngredient(ItemID.Waterleaf)
                .AddIngredient(ItemID.BottledWater)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
