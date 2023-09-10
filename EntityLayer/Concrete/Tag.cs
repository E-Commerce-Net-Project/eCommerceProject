using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class Tag : BaseEntity
    {
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public List<Product> Products { get; } = new();
    }
}
