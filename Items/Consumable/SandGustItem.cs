using System;
using Critters.NPCs.Fish;
using Critters.NPCs.Sky;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Consumable
{
    public class SandGustItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 36;
			Item.height = 24;
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
        
        public override bool? UseItem(Player player)
        {
	        NPC.NewNPC(new EntitySource_ItemUse(player, Item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<SandGust>());
	        return true;
        }
        
		public override void AddRecipes()
		{
			Recipe.Create(ItemID.SandstorminaBottle)
				.AddIngredient(ModContent.ItemType<SandGustItem>(), 5)
				.AddIngredient(ItemID.Bottle, 1)
				.AddTile(TileID.WorkBenches)
				.Register();
        }
	}
}
