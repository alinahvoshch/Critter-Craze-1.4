using System;

using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class BabySlimeBlue : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 20;
			Item.height = 12;
            
            Item.rare = ItemRarityID.Blue;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.maxStack = 99;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;
            
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }

        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<NPCs.Slime.BabySlimeBlue>());
            return true;
        }
    }
}
