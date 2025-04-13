using Critters.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Critters.Items.Plants
{
    public class Boquet : ModItem
    {
	    public int WillGenn = 0;
	    public int Meme;

        public override void SetDefaults()
        {
            Item.width = Item.height = 40;
            Item.rare = ItemRarityID.Green;
            Item.maxStack = 1;
            Item.noUseGraphic = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 60;
            Item.value = Item.sellPrice(0, 3, 0, 0);
			Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.noMelee = true;
            Item.consumable = true;
            Item.autoReuse = false;

        }
        public override bool? UseItem(Player player)
        {
            #region Plants
            {
	            Main.NewText("Plants have sprouted up everywhere!", Color.Green.R, Color.Green.G, Color.Green.B);
	            
	            for (int C = 0; C < Main.maxTilesX * 6; C++)
	            {
		            {
			            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
			            int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
			            
			            if (Main.tile[X,Y].TileType == TileID.Stone)
			            {
				            WorldGen.PlaceObject(X, Y, ModContent.TileType<DeathCap>());
				            NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<DeathCap>(), 0,0, -1, -1);
			            }
		            }


	            }

	            for (int C = 0; C < Main.maxTilesX * 6; C++)
	            {
		            {
			            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
			            int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
			            if (Main.tile[X,Y].TileType == TileID.Stone)
			            {
				            WorldGen.PlaceObject(X, Y, ModContent.TileType<DeathCap>());
				            NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<DeathCap>(), 0,0, -1, -1);

			            }
		            }


	            }
	            for (int C = 0; C < Main.maxTilesX * 4; C++)
	            {
		            {
			            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
			            int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
			            if (Main.tile[X,Y].TileType == TileID.IceBlock)
			            {
				            WorldGen.PlaceObject(X, Y, ModContent.TileType<Cryovine>());
				            NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<Cryovine>(), 0,0, -1, -1);
			            }
		            }


	            }

	            for (int C = 0; C < Main.maxTilesX * 4; C++)
	            {
		            {
			            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
			            int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
			            if (Main.tile[X,Y].TileType == TileID.IceBlock)
			            {
				            WorldGen.PlaceObject(X, Y, ModContent.TileType<Cryovine>());
				            NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<Cryovine>(), 0,0, -1, -1);
			            }
		            }


	            }
	            for (int C = 0; C < Main.maxTilesX * 3; C++)
	            {
		            {
			            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
			            int Y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
			            {
				            if (Main.tile[X, Y].LiquidAmount == 255)
				            {
					            WorldGen.PlaceObject(X, Y, ModContent.TileType<GhostReed>());
					            NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<GhostReed>(), 0,0, -1, -1);
				            }
			            }
		            }


	            }

	            for (int C = 0; C < Main.maxTilesX * 3; C++)
	            {
		            {
			            int X = WorldGen.genRand.Next(0, Main.maxTilesX);
			            int Y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
			            {
				            if (Main.tile[X, Y].LiquidAmount == 255)
				            {
					            WorldGen.PlaceObject(X, Y, ModContent.TileType<GhostReed>());
					            NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<GhostReed>(), 0,0, -1, -1);
				            }
			            }
		            }


	            }


            }
            #endregion
            return true;
        }

        }
}
