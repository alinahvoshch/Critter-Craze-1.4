using Critters.Buffs;
using Critters.Items.Consumable;
using Critters.Items.Placeable;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace Critters
{
	public class MyPlayer : ModPlayer
	{
		public bool ColdHeartBuff;
		public bool Alchemical;
		public bool UFOPet = false;
		public override void ResetEffects()
		{
			ColdHeartBuff = false;
			Alchemical = false;
			UFOPet = false;
		}

		public override void CatchFish(FishingAttempt attempt, ref int itemDrop, ref int npcSpawn, ref AdvancedPopupRequest sonar,
			ref Vector2 sonarPosition)
		{
			if (itemDrop == ItemID.OldShoe || itemDrop == ItemID.Seaweed || itemDrop == ItemID.TinCan)
				return;

			MyPlayer modPlayer = Player.GetModPlayer<MyPlayer>();
			if (Player.ZoneBeach && Main.rand.NextBool(35))
			{
				itemDrop = ModContent.ItemType<FishCrate>();
			}
			if (Main.rand.NextBool(15)&& Player.ZoneBeach)
			{
				itemDrop = ModContent.ItemType<KelpfishItem>();
			}
			if (Main.rand.NextBool(15)&& Player.ZoneBeach)
			{
				itemDrop = ModContent.ItemType<CoralfishItem>();
			}
			if (Main.rand.NextBool(18)&& Player.ZoneBeach && !Main.dayTime)
			{
				itemDrop = ModContent.ItemType<FloaterItem>();
			}
			if (Main.rand.NextBool(15)&& Player.ZoneRockLayerHeight)
			{
				itemDrop = ModContent.ItemType<LanternfishItem>();
			}
			if (Main.rand.NextBool(18)&& Player.ZoneRockLayerHeight)
			{
				itemDrop = ModContent.ItemType<LuvdiscItem>();
			}
		}


		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (ColdHeartBuff && Main.rand.NextBool(2))
			{
				Projectile.NewProjectile(new EntitySource_OnHit(Player, target), target.Center.X + Main.rand.Next(-5, 5),
					target.Center.Y - 1000, 0, Main.rand.Next(40, 45), ProjectileID.Blizzard, 25, 0, Player.whoAmI);

			}
			if (ColdHeartBuff && Main.rand.NextBool(10))
			{
				Player.AddBuff(BuffID.Chilled, 120);

			}
			if (Alchemical && Main.rand.NextBool(10))
			{
				target.AddBuff(ModContent.BuffType<Alchemical_Buff>(), 240);

			}
		}

		public override void OnHitNPCWithProj(Projectile proj, NPC target, NPC.HitInfo hit, int damageDone)
		{
			if (ColdHeartBuff && Main.rand.NextBool(2))
			{
				if (proj.type != ProjectileID.Blizzard)
				{
					Projectile.NewProjectile(new EntitySource_OnHit(Player, target), target.Center.X + Main.rand.Next(-5, 5),
						target.Center.Y - 1000, 0, Main.rand.Next(40, 45), ProjectileID.Blizzard, 25, 0, Player.whoAmI);				}

			}
			if (ColdHeartBuff && Main.rand.NextBool(10))
			{
				Player.AddBuff(BuffID.Chilled, 120);

			}
			if (Alchemical && Main.rand.NextBool(10))
			{
				target.AddBuff(ModContent.BuffType<Alchemical_Buff>(), 240);
			}
		}
	}
}