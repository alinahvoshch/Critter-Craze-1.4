using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Critters.Items.Lumoth
{
    public class Brightbulb : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 14;
			Item.height = 20;
            Item.rare = 2;
            Item.maxStack = 99; 
            Item.autoReuse = false;

        }
        
        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

    }
}
