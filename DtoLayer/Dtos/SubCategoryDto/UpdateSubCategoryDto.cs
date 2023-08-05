using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.SubCategoryDto
{
    public class UpdateSubCategoryDto
    {
        public int SubCategoryID { get; set; }
        public string Name { get; set; }
        public int GenreCategoryID { get; set; }
    }
}
