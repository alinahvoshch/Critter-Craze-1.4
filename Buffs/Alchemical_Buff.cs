using System;

using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Critters.NPCs;

namespace Critters.Buffs
{
	public class Alchemical_Buff : ModBuff
	{

		public override void SetStaticDefaults()
		{
			Main.pvpBuff[Type] = true;
			Main.buffNoTimeDisplay[Type] = false;
		}

		public override void Update(Player player, ref int buffIndex)
		{
			MyPlayer modPlayer = player.GetModPlayer<MyPlayer>();
			modPlayer.Alchemical = true;
			if (player.lifeRegen > 0)
				player.lifeRegen = 0;
			player.lifeRegen -= 4;
		}
		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.GetGlobalNPC<GlobalCritterNPC>().alchemical = true;
			if (Main.rand.NextBool(3))
			{
				int dust = Dust.NewDust(npc.position, npc.width, npc.height, DustID.Blood);
				Main.dust[dust].scale = 1.5f;
				Main.dust[dust].noGravity = true;
			}
		}
	}
}
