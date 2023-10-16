using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public string Section { get; set; }

        #region ProductDetail
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public string Image5 { get; set; }
        public string NameDetail { get; set; }
        public string DescriptionDetail { get; set; }
        public string SKU { get; set; }
        public string Dimension { get; set; }
        public string Models { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public string Dupatta { get; set; }
        #endregion

        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public int GenreCategoryID { get; set; }
        public GenreCategory GenreCategory { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
        //public ICollection<ProductDetail> ProductDetails { get; set; }
        public ICollection<Stock> Stocks { get; set; }

        //Many-to-Many Relationships
        public List<Color> Colors { get; } = new();
        public List<BodySize> BodySizes { get; } = new();
        public List<Tag> Tags { get; } = new();
        public List<WishList> WishLists { get; } = new();
        public List<Comment> Comments { get; } = new();
    }
}
