using System.Collections.Generic;
using Critters.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class MusketeerHat : ModItem
	{
		public static int _type;


        public int timer = 0;
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;

            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
		 public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CrimsonFeather>(), 2)
                .AddIngredient(ItemID.Silk, 6)
                .AddTile(TileID.Loom)
                .Register();
        }
    }
}
