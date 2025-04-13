using System;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles.Furniture
{
	public class Streetlamp : ModTile
	{
		public override void SetStaticDefaults()
		{
			RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.Streetlamp>());
			
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			Main.tileLighted[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.newTile.Height = 5;
			TileObjectData.newTile.Width = 3;
			TileObjectData.newTile.CoordinateHeights = [16, 16, 16, 16, 16];
			
			TileObjectData.addTile(Type);
			
			AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
			DustType = 8;
			AddMapEntry(new Color(114, 114, 114), Language.GetText("MapObject.Chandelier"));
			AdjTiles = [TileID.Chandeliers];
			
		}

		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = 1.0f;
			g = 0.9f;
			b = 0.8f;
		}

		public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
		
	}
}