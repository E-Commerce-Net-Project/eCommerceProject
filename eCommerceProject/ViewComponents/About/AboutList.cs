using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.ViewComponents.About
{
    public class AboutList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
