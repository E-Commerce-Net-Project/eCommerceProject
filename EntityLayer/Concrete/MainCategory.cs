using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class MainCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
