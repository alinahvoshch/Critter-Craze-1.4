using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;

namespace Critters.Tiles.Catchers
{
	public class DreamCatcher_Tile : ModTile
	{
		public override void SetStaticDefaults()
		{
			RegisterItemDrop(ModContent.ItemType<Items.Placeable.Furniture.DreamCatcher>());
			
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
			TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.Width = 3;
			
			TileObjectData.newTile.CoordinateHeights = [16, 16, 16];

			DustType = 7;
			AddMapEntry(new Color(130, 88, 20));
			
			TileObjectData.addTile(Type);
		}
		
		public override void SetDrawPositions(int i, int j, ref int width, ref int offsetY, ref int height, ref short tileFrameX, ref short tileFrameY)
		{
			Tile tile = Main.tile[i, j];
			TileObjectData data = TileObjectData.GetTileData(tile);
			int topLeftX = i - tile.TileFrameX / 18 % data.Width;
			int topLeftY = j - tile.TileFrameY / 18 % data.Height;
			if (WorldGen.IsBelowANonHammeredPlatform(topLeftX, topLeftY))
			{
				offsetY -= 8;
			}
		}
		
		public virtual void SafeNearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				player.buffImmune[BuffID.Darkness] = true;
				player.buffImmune[BuffID.Silenced] = true;
			}
		}
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			SafeNearbyEffects(i, j, closer);
		}
	}
}