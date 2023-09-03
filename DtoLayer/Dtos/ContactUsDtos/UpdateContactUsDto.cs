using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ContactUsDtos
{
    public class UpdateContactUsDto
    {
        public int ContactUsID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
		public DateTime MessageSentTime { get; set; }
	}
}
