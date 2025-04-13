using System.Collections.Generic;
using Critters.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles
{
	public class Kelp : ModTile
	{
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = false;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
			TileObjectData.newTile.Height = 6;
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16,
				16,
				16,
				16,
				16
			};


			AdjTiles = [TileID.GrandfatherClocks];
			TileObjectData.newTile.DrawYOffset = 2;
			TileObjectData.addTile(Type);


			LocalizedText name = CreateMapEntryName();
			AddMapEntry(new Color(86, 158, 89), name);

			DustType = 2;

		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;

		public override IEnumerable<Item> GetItemDrops(int i, int j)
		{
			yield return new Item(ModContent.ItemType<Items.Plants.Kelp>(), Main.rand.Next(10) + 5);
			if (Main.rand.NextBool(23))
			{
				yield return new Item(ModContent.ItemType<Items.KelpHook>());
			}
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			SoundEngine.PlaySound(SoundID.Grass, new Vector2(i * 16, j * 16));

		}
	}
}
