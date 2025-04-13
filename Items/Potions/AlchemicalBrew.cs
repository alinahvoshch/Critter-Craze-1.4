using System;
using Critters.Buffs;
using Critters.Items.Plants;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Potions
{
    public class AlchemicalBrew : ModItem
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

            Item.buffType = ModContent.BuffType<Alchemical_Buff>();
            Item.buffTime = 14600;

            Item.UseSound = SoundID.Item3;
        }
        
        
        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<DeathCapItem>())
                .AddIngredient(ItemID.Deathweed, 1)
                .AddIngredient(ItemID.BottledWater, 1)
                .AddTile(TileID.Bottles)
                .Register();
        }
    }
}
