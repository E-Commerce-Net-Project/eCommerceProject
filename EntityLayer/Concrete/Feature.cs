using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class Feature : BaseEntity
    {
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string ImageURl { get; set; }
        public string Description { get; set; }
    }
}
