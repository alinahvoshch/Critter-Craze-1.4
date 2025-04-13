using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System.IO;
using Critters.NPCs.Fish;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;


namespace Critters.Items
{
	public class GItem : GlobalItem
	{
		public override bool InstancePerEntity => true;
		protected override bool CloneNewInstances => true;
		
		public override void SetDefaults(Item item)
		{
			if (item.type == ItemID.HelFire)
			{
				CrittersGlowmask.AddGlowMask(item.type, "Critters/Glowmask/Helfire");
			}
			
			if (item.type == ItemID.ArmoredCavefish)
			{ 
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			
			if (item.type == ItemID.Damselfish)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.CrimsonTigerfish)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.GoldenCarp)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.SpecularFish)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.Prismite)
			{ 
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.Ebonkoi)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.NeonTetra)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.AtlanticCod)
			{ 
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.FrostMinnow)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
			if (item.type == ItemID.RedSnapper)
			{
				item.useStyle = ItemUseStyleID.Swing;
	            item.useTime = item.useAnimation = 20;
	            item.noMelee = true;
	            item.consumable = true;
	            item.autoReuse = true;
			}
		}
		
		public override void PostDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
		{
			if (item.type == ItemID.HelFire)
			{
				Texture2D texture = TextureAssets.Item[item.type].Value;
				Texture2D glowtexture = ModContent.Request<Texture2D>("Critters/Glowmask/Helfire").Value;
				spriteBatch.Draw
				(
					glowtexture,
					new Vector2
					(
						item.position.X - Main.screenPosition.X + item.width * 0.5f,
						item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
					),
					new Rectangle(0, 0, texture.Width, texture.Height),
					Color.White,
					rotation,
					texture.Size() * 0.5f,
					scale,
					SpriteEffects.None,
					0f
				);
			}

		}
		public override bool? UseItem(Item item, Player player)
        {
			if (item.type == ItemID.AtlanticCod)
			{
				 NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<AtlanticCod>());
				 return true;
			}
			
			if (item.type == ItemID.NeonTetra)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<NeonTetra>());
				return true;
			}
			
			if (item.type == ItemID.ArmoredCavefish)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Cavefish>());
				return true;
			}
			
			if (item.type == ItemID.Damselfish)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Damselfish>());
				return true;
			}
			
			if (item.type == ItemID.CrimsonTigerfish)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<CrismonTigerfish>());
                return true;
			}
			
			if (item.type == ItemID.GoldenCarp)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<GoldenCarp>());
				return true;
			}
			
			if (item.type == ItemID.SpecularFish)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<SpecularFish>());
                return true;
			}
			
			if (item.type == ItemID.Prismite)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<Prismite>());
				return true;
			}
			
			if (item.type == ItemID.FrostMinnow)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<FrostMinnow>());
                return true;
			}
			
			if (item.type == ItemID.RedSnapper)
			{
				NPC.NewNPC(new EntitySource_ItemUse(player, item), (int)player.Center.X, (int)player.Center.Y, ModContent.NPCType<RedSnapper>());
				return true;
			}

			return null;
        }
	}
}