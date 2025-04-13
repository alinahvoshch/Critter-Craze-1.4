using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Armor.Vanity
{
    [AutoloadEquip(EquipType.Head)]
    public class Skull : ModItem
	{
		public static int _type;

        public int timer = 0;
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 18;

            Item.value = Item.sellPrice(0, 0, 7, 20);
            Item.rare = ItemRarityID.Blue;
            Item.vanity = true;
        }
    }
}
