using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.GenreCategoryDtos
{
    public class UpdateGenreCategoryDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SubCategoryID { get; set; }
    }
}
