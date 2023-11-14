namespace eCommerceProject.Helpers
{
    public class ImageHelper
    {
        private readonly string _resource;

        public ImageHelper(string resource)
        {
            _resource = resource;
        }

        public string SaveImage(IFormFile imageFile)
        {
            var extension = Path.GetExtension(imageFile.FileName);
            var imageName = Guid.NewGuid() + extension;
            var saveLocation = Path.Combine(_resource, "wwwroot/ProductImages", imageName);

            using (var stream = new FileStream(saveLocation, FileMode.Create))
            {
                imageFile.CopyTo(stream);
            }

            return "/ProductImages/" + imageName;
        }
    }
}
