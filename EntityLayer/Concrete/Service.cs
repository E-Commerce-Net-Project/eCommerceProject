using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace EntityLayer.Concrete
{
    public class Service : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
