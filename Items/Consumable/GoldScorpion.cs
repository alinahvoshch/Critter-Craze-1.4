using System;
using Critters.NPCs.Lizard;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class GoldScorpion : ModItem
    {
        public override void SetDefaults()
        {
            Item.height = 18;
			Item.width = 32;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(0, 10, 0, 0);
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }
        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<GoldScorp>());
            return true;
        }

    }
}
