using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.GenreCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public string NameDetail { get; set; }
        public string DescriptionDetail { get; set; }
        public string SKU { get; set; }
        public string Dimension { get; set; }
        public string Models { get; set; }
        public string Top { get; set; }
        public string Bottom { get; set; }
        public string Dupatta { get; set; }
        public string Section { get; set; }

        public int GenreCategoryID { get; set; }
        public ResultGenreCategoryDto GenreCategory { get; set; }
        public int BrandID { get; set; }
        public ResultBrandDto Brand { get; set; }

    }
}
