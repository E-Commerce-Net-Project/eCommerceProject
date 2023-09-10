using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class MainCategory : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
