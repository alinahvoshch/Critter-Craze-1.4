using Critters.Projectiles.Pets;
using Terraria;
using Terraria.ModLoader;

namespace Critters.Buffs.Pets
{
	public class UFOPet_Buff : ModBuff
	{
		public override void SetStaticDefaults() {
			Main.buffNoTimeDisplay[Type] = true;
			Main.vanityPet[Type] = true;
		}

		public override void Update(Player player, ref int buffIndex) {
			bool unused = false;
			player.BuffHandle_SpawnPetIfNeededAndSetTime(buffIndex, ref unused, ModContent.ProjectileType<UFOPet>());
		}
	}
}