using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using System;
using Critters.Items.Consumable;
using Critters.Projectiles.Summon;
using Terraria.DataStructures;

namespace Critters.Items.Weapons.Summon
{
	public class IgnomeStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			CrittersGlowmask.AddGlowMask(Item.type, "Critters/Glowmask/IgnomeStaff");
        }

		public override void SetDefaults()
		{
            Item.width = 26;
            Item.height = 28;
            Item.value = Item.sellPrice(0, 2, 3, 0);
            Item.rare = ItemRarityID.Yellow;
            
            Item.mana = 12;
            Item.damage = 81;
            Item.knockBack = 1f;
            Item.DamageType = DamageClass.Summon;
            
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = Item.useAnimation = 30;
            Item.noMelee = true;
            Item.UseSound = SoundID.Item44;
            
            Item.shoot = ModContent.ProjectileType<IgnomeSummon>();

        }
					public override bool AltFunctionUse(Player player)
        {
            return true;
        }
        
        public override bool? UseItem(Player player)
        {
            if(player.altFunctionUse == 2)
            {
                player.MinionNPCTargetAim(false);
            }
            
            return base.UseItem(player);
        }
        
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
        {
	        Texture2D texture = ModContent.Request<Texture2D>("Critters/Items/Weapons/IgnomeStaff").Value;
	        Texture2D glowtexture = ModContent.Request<Texture2D>("Critters/Glowmask/IgnomeStaff").Value;
	        spriteBatch.Draw
	        (
		        glowtexture,
		        new Vector2
		        (
			        Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
			        Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
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

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage,
	        ref float knockback)
        {
	        position = Main.MouseWorld;
	        velocity = Vector2.Zero;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type,
	        int damage, float knockback)
        {
	        if (player.altFunctionUse == 2)
		        return false;
	        
	        return true;
        }

        public override void AddRecipes()
        {
	        CreateRecipe()
		        .AddIngredient(ModContent.ItemType<IgnomeItem>(), 6)
		        .AddIngredient(ItemID.LihzahrdPowerCell, 1)
		        .AddIngredient(ItemID.LunarTabletFragment, 12)
		        .AddTile(TileID.TinkerersWorkbench)
		        .Register();
        }
    }
}