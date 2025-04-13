using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Critters.NPCs;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Tiles
{
	public class CGlobalTile : GlobalTile
	{
		private readonly int[] TileArray2 = [0, 3, 185, 186, 187, 71, 28];

		public override void RandomUpdate(int i, int j, int type)
        {
			if (type == 53) //add water support later
			{
				bool place = false;
				for (int x = i - 5; x < i + 5; x++)
				{
					for (int y = j; y < j + 5; y++)
					{
						if (Main.tile[x, y].LiquidAmount == 255)
						{
							place = true;
						}
					}
				}				
				if(TileArray2.Contains(Framing.GetTileSafely(i,j-1).TileType) && (i < (Main.maxTilesX / 5) || i > Main.maxTilesX - (Main.maxTilesX / 5)) && place)
				{
                    if(Main.rand.NextBool(40))
                    {
                         int why = Main.rand.Next(8);
						WorldGen.PlaceObject(i,j-why,ModContent.TileType<Kelp>());
                        NetMessage.SendObjectPlacement(-1,i,j-why,ModContent.TileType<Kelp>(),0,0,-1,-1);
						
                    }            
                }
			}
		}
		public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
		{
			if (type == 129)
			{
				if (Main.rand.NextBool(12))
				{
					NPC.NewNPC(new EntitySource_WorldGen(),(int)i * 16, (int)j * 16, ModContent.NPCType<Crismite>(), 0, 2, 1, 0, 0, Main.myPlayer);			
				}
			}
			/*if (type == mod.TileType("GhostReed") && player.ZoneBeach)
			{
			{
			Item.NewItem(i * 16, j * 16, 32, 48, mod.ItemType("Kelp"), Main.rand.Next(2) + 1);			
			}
			}*/
		}		
	}	
}
