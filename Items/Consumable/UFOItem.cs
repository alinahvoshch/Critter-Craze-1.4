using System;
using Critters.NPCs;
using Critters.NPCs.Sky;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class UFOItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 36;
			Item.height = 24;
            Item.rare = ItemRarityID.Yellow;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
			Item.value = Item.sellPrice(0, 0, 40, 0);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }

        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<UFO>());
            return true;
        }

    }
}
