﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
