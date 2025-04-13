using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Critters.Items.Materials;
using Critters.Projectiles.Magic;

namespace Critters.Items.Weapons.Magic
{
    public class CrystalRefractor : ModItem
    {
        public override void SetStaticDefaults()
        {
            CrittersGlowmask.AddGlowMask(Item.type, "Critters/Glowmask/Crismite");
        }

        public override void SetDefaults()
        {
            Item.damage = 43;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 9;
            Item.width = Item.height = 40;
            
            Item.useTime = Item.useAnimation = 32;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.staff[Item.type] = true;
            Item.noMelee = true;
            Item.knockBack = 1;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = ItemRarityID.LightPurple;
            Item.UseSound = SoundID.Item8;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CrystalProj>();
            Item.shootSpeed = 20f;
        }

        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float  scale, int whoAmI) 	
        {
            Texture2D texture = ModContent.Request<Texture2D>("Critters/Items/Consumable/CrystalRefactor").Value;
            Texture2D glowtexture = ModContent.Request<Texture2D>("Critters/Glowmask/Crismite").Value;
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

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<CrismiteCrystal>(), 1)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
