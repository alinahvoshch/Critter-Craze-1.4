using Critters.Items.Consumable;
using Critters.NPCs;
using Critters.NPCs.Evil;
using Critters.NPCs.Fish;
using Critters.NPCs.Lizard;
using Critters.NPCs.Moths;
using Critters.NPCs.Ocean;
using Critters.NPCs.Sky;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using BabySlimeGreen = Critters.NPCs.Slime.BabySlimeGreen;
using BabySlimeIce = Critters.NPCs.Slime.BabySlimeIce;

namespace Critters.Tiles.Banner
{
	public abstract class BannerTile : ModTile
	{
		protected abstract int NPC { get; }
		protected abstract Color MapColor { get; }
		public override void SetStaticDefaults()
		{
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileLavaDeath[Type] = true;
			TileObjectData.newTile.CopyFrom(TileObjectData.GetTileData(TileID.Banners, 0));
			TileObjectData.newTile.StyleLineSkip = 2;
			TileObjectData.addTile(Type);
			AddMapEntry(MapColor, Language.GetText("MapObject.Banner"));
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
		
		public override bool CreateDust(int i, int j, ref int type) => false;
		
		public virtual void SafeNearbyEffects(int i, int j, bool closer)
		{
			if (closer)
			{
				Main.SceneMetrics.hasBanner = true;
				Main.SceneMetrics.NPCBannerBuff[NPC] = true;
			}
		}
		public override void NearbyEffects(int i, int j, bool closer)
		{
			SafeNearbyEffects(i, j, closer);
		}
	}
	
	public class CrimsonCluckBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<CrimsonCluck>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class GulperBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Gulper>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class BloodBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Bloodlurker>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class WatcherBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Watcher>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class LumothBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Lumoth>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class IgnomeBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Ignome>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class FloaterBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Floater>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class CrismiteBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Crismite>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class LuvdiscBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Luvdisc>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class GreyMothBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<GreyMoth>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class LunaMothBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<LunaMoth>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class JewelMothBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<JewelMoth>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class GoldMothBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<GoldMoth>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class GustBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Gust>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class StormGustBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<StormGust>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class SnowGustBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<SnowGust>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class SandGustBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<SandGust>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class UFOBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<UFO>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class LanternfishBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Lanternfish>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class GildJellyBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<GildJelly>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class KelpfishBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Kelpfish>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class CoralfishBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Glitterfish>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class LizardBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<Lizard>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class IceBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<BabySlimeIce>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class GreenBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<BabySlimeGreen>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class BlueBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<NPCs.Slime.BabySlimeBlue>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class SandBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<NPCs.Slime.BabySlimeSand>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
	public class RainbowBanner : BannerTile
	{
		protected override int NPC => ModContent.NPCType<NPCs.Slime.BabySlimeRainbow>();
		protected override Color MapColor => new Color(13, 88, 130);
	}
}