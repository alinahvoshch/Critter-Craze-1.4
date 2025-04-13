using System;
using Critters.NPCs.Moths;
using Critters.NPCs.Sky;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Moths
{
    public class GoldMothItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 24;
			Item.height = 22;
            Item.rare = ItemRarityID.Orange;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.useTime = Item.useAnimation = 20;
			Item.bait = 50;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = false;

        }
        
        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<GoldMoth>());
            return true;
        }

    }
}
