using System;
using Critters.Projectiles;
using Terraria.ModLoader;
using Terraria.ID;

namespace Critters.Items
{
	internal class KelpHook : ModItem
	{
		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.AmethystHook);
			
			Item.shootSpeed = 18f;
			Item.shoot = ModContent.ProjectileType<KelpHookHead>();
		}
	}
}
