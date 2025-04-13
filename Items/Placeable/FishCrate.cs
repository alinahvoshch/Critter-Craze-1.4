using System;
using Critters.Items.Consumable;
using Critters.Items.Fish;
using Critters.Tiles.Furniture;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Critters.Items.Placeable
{
    public class FishCrate : ModItem
    {
	    public override void SetStaticDefaults() {
		    ItemID.Sets.IsFishingCrate[Type] = true;
		    Item.ResearchUnlockCount = 10;
	    }
	    
        public override void SetDefaults()
        {
	        Item.DefaultToPlaceableTile(ModContent.TileType<FishCrate_Tile>());
            Item.width = 20;
            Item.height = 20;
            Item.rare  = ItemRarityID.Orange;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.createTile = ModContent.TileType<FishCrate_Tile>();
            Item.maxStack = 999;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
	        Item.consumable = true;

        }
        
        public override void ModifyResearchSorting(ref ContentSamples.CreativeHelper.ItemGroup itemGroup) {
	        itemGroup = ContentSamples.CreativeHelper.ItemGroup.Crates;
        }
        
        public override bool CanRightClick()
        {
            return true;
        }
        
		public override void Update(ref float gravity, ref float maxFallSpeed)
        {
			if(Item.wet)
			{
				gravity *= 0f;
				maxFallSpeed *= -.09f;
			}
			else
			{
				maxFallSpeed *= 1f;
				gravity *= 1f;
			}
        }
		
		public override void ModifyItemLoot(ItemLoot itemLoot) {
			
			itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<RawFish>(), 2));
			itemLoot.Add(ItemDropRule.Common(ItemID.SilverCoin, 3, 10, 90));
			itemLoot.Add(ItemDropRule.Common(ItemID.GoldCoin, 7, 1, 2));
			
			IItemDropRule[] modFishTypes = [
				ItemDropRule.Common(ModContent.ItemType<FloaterItem>(), 2),
				ItemDropRule.Common(ModContent.ItemType<CoralfishItem>(), 2),
				ItemDropRule.Common(ModContent.ItemType<LuvdiscItem>(), 2),
				ItemDropRule.Common(ModContent.ItemType<LanternfishItem>(), 2),
				ItemDropRule.Common(ModContent.ItemType<KelpfishItem>(), 2),
			];
			itemLoot.Add(new OneFromRulesRule(4, modFishTypes));

			
			IItemDropRule[] vanillaCommonFishTypes = [
				ItemDropRule.Common(ItemID.Shrimp, 1, 3,5),
				ItemDropRule.Common(ItemID.Salmon, 1, 3,5),
				ItemDropRule.Common(ItemID.Bass, 1, 3, 5),
				ItemDropRule.Common(ItemID.RedSnapper, 1, 3, 5),
				ItemDropRule.Common(ItemID.Trout, 1, 3, 5),
			];
			itemLoot.Add(new OneFromRulesRule(1, vanillaCommonFishTypes));
			
			
			IItemDropRule[] vanillaUncommonFishTypes = [
				ItemDropRule.Common(ItemID.ArmoredCavefish, 1, 1, 2),
				ItemDropRule.Common(ItemID.Damselfish, 1, 1, 2),
				ItemDropRule.Common(ItemID.DoubleCod, 1, 1, 2),
				ItemDropRule.Common(ItemID.FrostMinnow, 1, 1, 2),
				];
			itemLoot.Add(new OneFromRulesRule(4, vanillaUncommonFishTypes));
			
			
			IItemDropRule[] vanillaSharks = [
				ItemDropRule.Common(ItemID.ReaverShark),
				ItemDropRule.Common(ItemID.Swordfish),
				ItemDropRule.Common(ItemID.SawtoothShark),
			];
			itemLoot.Add(new OneFromRulesRule(27, vanillaSharks));
			
			
			IItemDropRule[] vanillaResourceFish = [
				ItemDropRule.Common(ItemID.FrostDaggerfish, 1, 9, 12),
				ItemDropRule.Common(ItemID.BombFish, 1, 9, 12),
			];
			itemLoot.Add(new OneFromRulesRule(3, vanillaResourceFish));
			
			
			IItemDropRule[] vanillaHardmodeFish = [
				ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.FlarefinKoi),
				ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.Obsidifish),
				ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.Prismite),
				ItemDropRule.ByCondition(new Conditions.IsHardmode(), ItemID.PrincessFish),
			];
			
			itemLoot.Add(new OneFromRulesRule(10, vanillaHardmodeFish));
		}
	}
}
