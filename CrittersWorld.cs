using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using System.Reflection;
using Terraria.Utilities;
using System.Runtime.Serialization.Formatters.Binary;
using Critters.Tiles;
using Terraria.GameContent.Events;
using Terraria.IO;
using Terraria.Localization;
using Terraria.WorldBuilding;

namespace Critters
{
	public class CrittersWorld : ModSystem
	{
		public static bool Rain = false;
		public static bool sandStorm = false;
		public static int DeathTiles = 0;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
		{
			DeathTiles = tileCounts[ModContent.TileType<DeathCap>()];
		}

		public override void SaveWorldData(TagCompound tag)
		{
			tag["Rain"] = Rain;
			tag["SandStrom"] = sandStorm;
		}

		public override void LoadWorldData(TagCompound tag)
		{
			Rain = tag.ContainsKey("Rain");
			sandStorm = tag.ContainsKey("SandStrom");
		}

		public override void PostUpdateWorld()
		{
			if (Main.raining)
			{
				Rain = true;
			}
			else
			{
				Rain = false;
			}

			if (Sandstorm.Happening)
			{
				sandStorm = true;
			}
			else
			{
				sandStorm = false;
			}
		}

		public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
		{
			int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
			if (ShiniesIndex != -1)
			{
				tasks.Insert(ShiniesIndex + 1, new PlantsPass("PlantsPass", 237.4298f));
			}
		}
	}
	
	public class PlantsPass(string name, float loadWeight) : GenPass(name, loadWeight)
	{
		protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
		{
			progress.Message = Language.GetTextValue("Critters.WorldGen.PlantsMessage");
			
			for (int C = 0; C < Main.maxTilesX * 18; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
				if (Main.tile[X, Y].TileType == TileID.Stone)
				{
					WorldGen.PlaceObject(X, Y, ModContent.TileType<DeathCap>());
					NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<DeathCap>(), 0, 0, -1, -1);
				}
			}

			for (int C = 0; C < Main.maxTilesX * 18; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
				if (Main.tile[X, Y].TileType == TileID.Stone)
				{
					WorldGen.PlaceObject(X, Y, ModContent.TileType<DeathCap>());
					NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<DeathCap>(), 0, 0, -1, -1);
				}
			}

			for (int C = 0; C < Main.maxTilesX * 14; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
				if (Main.tile[X, Y].TileType == TileID.IceBlock)
				{
					WorldGen.PlaceObject(X, Y, ModContent.TileType<Cryovine>());
					NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<Cryovine>(), 0, 0, -1, -1);
				}
			}

			for (int C = 0; C < Main.maxTilesX * 14; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY);
				{
					WorldGen.PlaceObject(X, Y, ModContent.TileType<Cryovine>());
					NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<Cryovine>(), 0, 0, -1, -1);
				}
			}

			for (int C = 0; C < Main.maxTilesX * 16; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
				{
					if (Main.tile[X, Y].LiquidAmount == 255)
					{
						WorldGen.PlaceObject(X, Y, ModContent.TileType<GhostReed>());
						NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<GhostReed>(), 0, 0, -1, -1);
					}
				}
			}

			for (int C = 0; C < Main.maxTilesX * 16; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
				{
					if (Main.tile[X, Y].LiquidAmount == 255)
					{
						WorldGen.PlaceObject(X, Y, ModContent.TileType<GhostReed>());
						NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<GhostReed>(), 0, 0, -1, -1);
					}
				}
			}

			for (int C = 0; C < Main.maxTilesX * 16; C++)
			{
				int X = WorldGen.genRand.Next(0, Main.maxTilesX);
				int Y = WorldGen.genRand.Next((int)Main.worldSurface, Main.maxTilesY);
				{
					if (Main.tile[X, Y].LiquidAmount == 255)
					{
						WorldGen.PlaceObject(X, Y, ModContent.TileType<Kelp>());
						NetMessage.SendObjectPlacement(-1, X, Y, ModContent.TileType<Kelp>(), 0, 0, -1, -1);
					}
				}
			}
		}
	}
}