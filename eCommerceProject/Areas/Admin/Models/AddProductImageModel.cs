namespace eCommerceProject.Areas.Admin.Models
{
    public class AddProductImageModel
    {
        public IFormFile coverImage { get; set; }
        public IFormFile Image1 { get; set; }
        public IFormFile Image2 { get; set; }
        public IFormFile Image3 { get; set; }
        public IFormFile Image4 { get; set; }
        public IFormFile Image5 { get; set; }
    }
}
