﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SubCategoryDtos
{
    public class CreateSubCategoryDto
    {
        public string Name { get; set; }
        public int MainCategoryID { get; set; }
    }
}
