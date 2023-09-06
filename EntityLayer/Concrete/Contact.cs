using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Common;

namespace EntityLayer.Concrete
{
    public class Contact : BaseEntity
    {
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHour { get; set; }
        public string Iframe { get; set; }
    }
}
