using System;
using Critters.NPCs;
using Critters.NPCs.Evil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class BlossmoonItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
			Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 20;

            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = true;

        }
        
        public override bool? UseItem(Player player)
        {
            NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Blossmoon>());
            return true;
        }

    }
}
