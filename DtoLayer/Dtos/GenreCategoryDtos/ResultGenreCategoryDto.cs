using DtoLayer.Dtos.SubCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.GenreCategoryDtos
{
    public class ResultGenreCategoryDto
    {
        public int GenreCategoryID { get; set; }
        public string Name { get; set; }
        public ResultSubCategoryDto SubCategory { get; set; }
    }
}
