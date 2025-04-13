using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class CrimsonFeather : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
			Item.height = 22;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.noMelee = true;
            Item.autoReuse = false;
        }
    }
}
