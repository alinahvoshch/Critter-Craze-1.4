using System.Collections.Generic;
using Critters.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Armor.Equip
{
    [AutoloadEquip(EquipType.Neck)]
    public class DuneCharm : ModItem
	{
		public static int _type;


		public int timer = 0;
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 18;
			Item.defense = 3;
            Item.accessory = true;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = ItemRarityID.Green;
        }
		public override void UpdateAccessory(Player player, bool hideVisual)
        {
			 player.buffImmune[BuffID.WindPushed] = true;
		}
		
		 public override void AddRecipes()
		 {
			 CreateRecipe()
				 .AddIngredient(ModContent.ItemType<CleftShell>(), 1)
				 .AddIngredient(ItemID.Chain, 6)
				 .AddIngredient(ItemID.Bone, 10)
				 .AddTile(TileID.Anvils)
				 .Register();
        }
    }
}
