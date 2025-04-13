using Critters.Items.Plants;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Critters.Tiles
{
    public class DeathCap : ModTile
    {
        public override void SetStaticDefaults()
        {
            RegisterItemDrop(ModContent.ItemType<DeathCapItem>());
            Main.tileFrameImportant[Type] = true;
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
                16,
                16
            };

            TileObjectData.addTile(Type);
			
            DustType = 5;
            
            LocalizedText name = CreateMapEntryName();
            AddMapEntry(new Color(255, 60, 40), name);

            
        }
		
        public override void NumDust(int i, int j, bool fail, ref int num) => num = fail ? 1 : 3;
        
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
			 SoundEngine.PlaySound(SoundID.NPCHit19, new Vector2(i * 16, j * 16));
        }
    
    }
}
