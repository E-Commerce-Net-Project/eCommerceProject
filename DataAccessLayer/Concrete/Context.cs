using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=EFRUN\\SQLEXPRESS; initial catalog=EcommerceDB; integrated Security=true;Trust Server Certificate=true;");
        } // . Bu bilgisayara demek değiştirmenize gerek yok sadece update-database yazacaksınız package manager console'a

        public DbSet<About> Abouts { get; set; }
        public DbSet<BodySize> BodySizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<GenreCategory> GenreCategories { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<WishList> WishLists { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //    .HasMany(e => e.BodySizes)
        //    .WithMany(e => e.Products)
        //    .UsingEntity(
        //        "ProductBodySize",
        //        l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductID").HasPrincipalKey(nameof(Product.ProductID)),
        //        r => r.HasOne(typeof(BodySize)).WithMany().HasForeignKey("BodySizeID").HasPrincipalKey(nameof(BodySize.BodySizeID)),
        //        j => j.HasKey("BodySizeID", "ProductID"));

        //    modelBuilder.Entity<Product>()
        //    .HasMany(e => e.Tags)
        //    .WithMany(e => e.Products)
        //    .UsingEntity(
        //        "ProductTag",
        //        l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductID").HasPrincipalKey(nameof(Product.ProductID)),
        //        r => r.HasOne(typeof(Tag)).WithMany().HasForeignKey("TagID").HasPrincipalKey(nameof(Tag.TagID)),
        //        j => j.HasKey("TagID", "ProductID"));

        //    modelBuilder.Entity<Product>()
        //    .HasMany(e => e.ProductColors)
        //    .WithMany(e => e.Products)
        //    .UsingEntity(
        //        "ProductColor",
        //        l => l.HasOne(typeof(Product)).WithMany().HasForeignKey("ProductID").HasPrincipalKey(nameof(Product.ProductID)),
        //        r => r.HasOne(typeof(ProductColor)).WithMany().HasForeignKey("ColorID").HasPrincipalKey(nameof(ProductColor.ColorID)),
        //        j => j.HasKey("ColorID", "ProductID"));
        //}
    }
}
