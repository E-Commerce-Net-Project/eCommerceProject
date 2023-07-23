using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ECommerceDbContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("ConnectionString");
        //}
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<BodySize> BodySizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany(e => e.Colors)
            .WithMany(e => e.Products)
            .UsingEntity(
                "ProductColor",
                l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.ProductId)),
                r => r.HasOne(typeof(Color)).WithMany().HasForeignKey("ProductColorId").HasPrincipalKey(nameof(Color.ColorId)),
                j => j.HasKey("ColorId", "ProductId"));

            modelBuilder.Entity<Product>()
            .HasMany(e => e.BodySizes)
            .WithMany(e => e.Products)
            .UsingEntity(
                "ProductBodySize",
                l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.ProductId)),
                r => r.HasOne(typeof(BodySize)).WithMany().HasForeignKey("BodySizeId").HasPrincipalKey(nameof(BodySize.BodySizeId)),
                j => j.HasKey("BodySizeId", "ProductId"));

            modelBuilder.Entity<Product>()
            .HasMany(e => e.Tags)
            .WithMany(e => e.Products)
            .UsingEntity(
                "ProductTag",
                l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductId").HasPrincipalKey(nameof(Product.ProductId)),
                r => r.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagId").HasPrincipalKey(nameof(Tag.TagId)),
                j => j.HasKey("TagId", "ProductId"));
        }

    }
}
