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
    public class Blossom : ModTile
    {
        public override void SetStaticDefaults()
        {
	        RegisterItemDrop(ModContent.ItemType<BlossomItem>());
            Main.tileFrameImportant[Type] = true;
			Main.tileFrameImportant[Type] = true;
			Main.tileSolid[Type] = false;
			Main.tileMergeDirt[Type] = true;
			Main.tileBlockLight[Type] = true;
			Main.tileLighted[Type] = true;
			
			
			TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
			
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(97, 120, 170), name);
			DustType = 187;
			TileObjectData.newTile.CoordinateHeights = [16, 16];

            TileObjectData.addTile(Type);
        }
		
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
		public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
		{
			r = .194f;
			g = .22f;
			b = 0.32f;
		}
		public virtual void SafeNearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Player player = Main.LocalPlayer;
				player.AddBuff(BuffID.Calm, 299);
			}
		}
		
		public override void NearbyEffects(int i, int j, bool closer)
		{
			SafeNearbyEffects(i, j, closer);
		}

		
		public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 2)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
		
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			 SoundEngine.PlaySound(SoundID.Item1, new Vector2(i * 16, j * 16));
	        
        }
		
	    public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
		{
			Tile tile = Main.tile[i, j];
			Vector2 zero = new Vector2(Main.offScreenRange, Main.offScreenRange);
			if (Main.drawToScreen)
			{
				zero = Vector2.Zero;
			}
			int height = (tile.TileFrameY == 36) ? 18 : 16;
			
			spriteBatch.Draw(ModContent.Request<Texture2D>("Critters/Tiles/Blossom_Glow").Value, new Vector2(i * 16 - (int)Main.screenPosition.X, j * 16 - (int)Main.screenPosition.Y) + zero, new Rectangle?(new Rectangle(tile.TileFrameX, tile.TileFrameY, 16, height)), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
			
		}
    }
}
