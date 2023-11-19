using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.GenreCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public ResultGenreCategoryDto GenreCategory { get; set; }
        public ResultBrandDto Brand { get; set; }
        public bool IsActive { get; set; }
    }
}
