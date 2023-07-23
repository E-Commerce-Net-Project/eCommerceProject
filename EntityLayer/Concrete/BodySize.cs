using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class BodySize
    {
        public int BodySizeID { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; } = new();
        public ICollection<Stock> Stocks { get; set; }
    }
}
