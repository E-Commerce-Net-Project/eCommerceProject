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
        public string Description { get; set; }
        public string Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }
        public string? Image4 { get; set; }
        public string? Image5 { get; set; }
        public string CoverImage { get; set; }
        public decimal Price { get; set; }
        public string Section { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int SubCategoryID { get; set; }
        public int BrandID { get; set; }
    }
}
