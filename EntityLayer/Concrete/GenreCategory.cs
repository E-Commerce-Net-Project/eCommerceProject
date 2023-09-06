using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class GenreCategory : BaseEntity
    {
        public string Name { get; set; }

        public int SubCategoryID { get; set; }
        public SubCategory SubCategory { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
