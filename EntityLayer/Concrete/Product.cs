using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public string Section { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<Stock> Stocks { get; set; }

        //Many-to-Many Relationships
        public List<Color> Colors { get; } = new();
        public List<BodySize> BodySizes { get; } = new();
        public List<Tag> Tags { get; } = new();
        public List<WishList> WishLists { get; } = new();
        public List<Comment> Comments { get; } = new();
    }
}
