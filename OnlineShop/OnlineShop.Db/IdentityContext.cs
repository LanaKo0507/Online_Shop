﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ModelsLibrary.ModelsDto;
using OnlineShop.Db.Helper;

namespace OnlineShop.Db
{
    public class IdentityContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<Compare> Compares { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ProductsImages> ImagesProducts { get; set; }
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                   .HasMany(p => p.Images)
                   .WithMany(i => i.Products)
                   .UsingEntity<ProductsImages>(
                       pi => pi.HasOne(prop => prop.Image).WithMany().HasForeignKey(prop => prop.ImageId),
                       pi => pi.HasOne(prop => prop.Product).WithMany().HasForeignKey(prop => prop.ProductId),
                       pi => pi.HasKey(prop => new { prop.ProductId, prop.ImageId}));

            base.OnModelCreating(builder);
            builder.Entity<Image>().HasData(ProductGenerator.GeneradeRandomImages());
            builder.Entity<Product>().HasData(ProductGenerator.GeneradeRandomProducts());
            builder.Entity<ProductsImages>().HasData(ProductGenerator.GeneradeRandomProductsImages());
        }
    }
}