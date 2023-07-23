using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Stock
    {
        public int StockID { get; set; }
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int ColorID { get; set; }
        public Color Color { get; set; }
        public int BodySizeID { get; set; }
        public BodySize BodySize { get; set; }
        public int StockQuantity { get; set; }
    }
}
