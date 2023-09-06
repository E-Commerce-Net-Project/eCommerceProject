using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class SocialMedia : BaseEntity
    {
        public string Icon { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

    }
}
