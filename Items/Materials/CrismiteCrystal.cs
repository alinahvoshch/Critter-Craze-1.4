using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Materials
{
    public class CrismiteCrystal : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 18;
            Item.rare = ItemRarityID.Pink;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 10, 0);
            Item.noMelee = true;
            Item.autoReuse = false;

        }
    }
}
