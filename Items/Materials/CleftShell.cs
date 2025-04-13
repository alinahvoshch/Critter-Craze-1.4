using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class CleftShell : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.noMelee = true;
            Item.autoReuse = false;

        }
    }
}
