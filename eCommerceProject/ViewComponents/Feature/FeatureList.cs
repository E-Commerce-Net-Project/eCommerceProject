using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.ViewComponents.Feature
{
    public class FeatureList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}