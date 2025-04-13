using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Consumable
{
    public class BabySlimeRainbow : ModItem
    {
		public override void SetStaticDefaults()
		{
		    Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
		}


        public override void SetDefaults()
        {
            Item.width = 20;
			Item.height = 12;
            Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(0, 1);
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
	        NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<NPCs.Slime.BabySlimeRainbow>());
	        return true;
        }

	}
}
