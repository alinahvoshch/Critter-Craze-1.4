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
    public class Cryovine : ModTile
    {
        public override void SetStaticDefaults()
        {
	        RegisterItemDrop(ModContent.ItemType<CryovineItem>());
            Main.tileFrameImportant[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            
			LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(66, 206, 244), name);
			DustType = 187;
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16,
				16
            };

            TileObjectData.addTile(Type);
        }
		
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .066f;
			g = .206f;
			b = 0.244f;
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			 SoundEngine.PlaySound(SoundID.Item27, new Vector2(i * 16, j * 16));
            
        }
		
	    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int height = (tile.TileFrameY == 54) ? 18 : 16;
			spriteBatch.Draw(ModContent.Request<Texture2D>("Critters/Tiles/Cryovine_Glow").Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X), (float)(j * 16 - (int)Main.screenPosition.Y)) + zero, new Rectangle?(new Rectangle((int)tile.TileFrameX, (int)tile.TileFrameY, 16, height)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
		}
    }
}
