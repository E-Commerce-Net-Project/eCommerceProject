using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ProductDetail
    {
        public int ProductDetailID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SKU { get; set; }
        public string Dimension { get; set; }
        public string Models { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public string Dupatta { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }

    }
}
