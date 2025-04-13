using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Buffs
{
	public class ColdHeart_Buff : ModBuff
	{
		public override void SetStaticDefaults()
		{
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.ColdHeartBuff = true;
			player.statDefense += 3;
		}
	}
}
