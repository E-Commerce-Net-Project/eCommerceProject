using DtoLayer.Dtos.MainCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SubCategoryDtos
{
    public class ResultSubCategoryDto
    {
        public int SubCategoryID { get; set; }
        public string Name { get; set; }
        public ResultMainCategoryDto MainCategory { get; set; }
    }
}
