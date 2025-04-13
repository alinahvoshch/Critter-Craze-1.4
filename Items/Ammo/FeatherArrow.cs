using System;
using Critters.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Ammo
{
	class FeatherArrow : ModItem
	{
        public override void SetDefaults()
        {
	        
            Item.width = 14;
			Item.height = 40;
            Item.value = Item.buyPrice(0, 0, 0, 6);
            Item.rare = ItemRarityID.Blue;

            Item.maxStack = Item.CommonMaxStack;

            Item.damage = 7;
			Item.knockBack = 2f;
            Item.ammo = AmmoID.Arrow;

            Item.DamageType = DamageClass.Ranged;
            Item.consumable = true;

            Item.shoot = ModContent.ProjectileType<Projectiles.Ammo.FeatherArrow>();
            Item.shootSpeed = 2.1f;
        }
		public override void AddRecipes()
		{
			CreateRecipe(100)
				.AddIngredient(ModContent.ItemType<CrimsonFeather>(), 1)
				.AddIngredient(ItemID.WoodenArrow, 100)
				.AddTile(TileID.WorkBenches)
				.Register();
		}		
	}
}
