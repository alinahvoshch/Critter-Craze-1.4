using System.Collections.Generic;
using Critters.Items.Plants;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles
{
    public class GhostReed : ModTile
    {
        public override void SetStaticDefaults()
        {

            Main.tileFrameImportant[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
           
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			TileObjectData.newTile.CoordinateHeights = new int[]
			{
				16,
				16
			};

			TileObjectData.addTile(Type);
            
			LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(97, 165, 120), name);
			DustType = 2;
            
        }
		
        public override void NumDust(int i, int j, bool fail, ref int num) =>  num = fail ? 1 : 3;
        
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .097f;
			g = .165f;
			b = 0.124f;
		}

		public override IEnumerable<Item> GetItemDrops(int i, int j)
		{
			if (!Main.dayTime)
			{
				yield return new Item(ModContent.ItemType<GhostReedItem>());
			}
		}

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			 SoundEngine.PlaySound(SoundID.Grass, new Vector2(i * 16, j * 16));
			 
             
        }
		
	    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			if (!Main.dayTime)
			{
				Tile tile = Main.tile[i, j];
				Vector2 zero = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
				if (Main.drawToScreen)
				{
					zero = Vector2.Zero;
				}
				int height = (tile.TileFrameY == 36) ? 18 : 16;
				spriteBatch.Draw(ModContent.Request<Texture2D>("Critters/Tiles/GhostReed_Glow").Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, new Rectangle?(new Rectangle((int)tile.TileFrameX, (int)tile.TileFrameY, 16, height)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			}
		}
    }
}
