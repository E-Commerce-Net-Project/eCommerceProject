using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class WishList : BaseEntity
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
