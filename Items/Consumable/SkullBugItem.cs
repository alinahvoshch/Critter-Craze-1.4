using System;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class SkullBugItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
			Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
			Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }
        // SkullBug doesn't exist XDDD
        //public override bool? UseItem(Player player)
        //{
       //     NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<SkullBug>());
       //     return true;
       // }
	}
	
}
