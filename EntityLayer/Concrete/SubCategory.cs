using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class SubCategory : BaseEntity
    {
        public string Name { get; set; }

        public int MainCategoryID { get; set; }
        public MainCategory MainCategory { get; set; }
        public ICollection<GenreCategory> GenreCategories { get; set; }

    }
}
