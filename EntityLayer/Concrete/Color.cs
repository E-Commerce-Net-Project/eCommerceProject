using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; } = new();
        public ICollection<Stock> Stocks { get; set; }
    }
}
