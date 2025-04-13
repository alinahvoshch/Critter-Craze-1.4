using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace Critters.Items.Plants
{
    public class Kelp : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 16;
			Item.height = 26;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 99;
            Item.noUseGraphic = true;
            Item.autoReuse = false;
        }
    }
}
