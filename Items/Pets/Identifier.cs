using Critters.Buffs.Pets;
using Critters.Items.Consumable;
using Critters.Projectiles.Pets;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Pets
{
	public class Identifier : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.Fish);
			Item.shoot = ModContent.ProjectileType<UFOPet>();
			Item.buffType = ModContent.BuffType<UFOPet_Buff>();
			Item.UseSound = SoundID.Item8;
			Item.rare = ItemRarityID.Pink;
		}

		public override void UseStyle(Player player, Rectangle heldItemFrame)
		{
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
			{
				player.AddBuff(Item.buffType, 3600, true);
			}
		}

		// public override bool CanUseItem(Player player)
		// {
		// 	return player.miscEquips[0].IsAir;
		// }
		
		 public override void AddRecipes()
		 {
			 CreateRecipe()
				 .AddIngredient(ModContent.ItemType<UFOItem>())
				 .AddIngredient(ItemID.SoulofSight)
				 .AddIngredient(ItemID.MartianConduitPlating, 30)
				 .AddTile(TileID.Anvils)
				 .Register();
        }
	}
}