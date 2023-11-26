using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.ViewComponents.Service
{
    public class ServiceList:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
