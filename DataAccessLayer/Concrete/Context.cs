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
            optionsBuilder.UseSqlServer("Data Source=SQL8005.site4now.net;Initial Catalog=db_a9ca78_ecommerce2023; User Id=db_a9ca78_ecommerce2023_admin; Password=ecommerce");
            //Ortak Database Server

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<BodySize> BodySizes { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUss { get; set; }
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
    }
}
