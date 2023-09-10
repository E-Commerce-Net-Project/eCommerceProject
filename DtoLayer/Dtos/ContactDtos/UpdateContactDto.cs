using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ContactDtos
{
    public class UpdateContactDto
    {
        public int ID { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHour { get; set; }
        public string Iframe { get; set; }
    }
}
