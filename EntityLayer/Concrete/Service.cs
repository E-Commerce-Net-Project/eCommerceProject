using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
