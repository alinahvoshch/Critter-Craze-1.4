using System;
using Critters.NPCs.Fish;
using Critters.NPCs.Lizard;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class LizardItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
			Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
			Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.useTime = Item.useAnimation = 20;
			Item.bait = 25;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }
        
        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Lizard>());
            return true;
        }


    }
}
