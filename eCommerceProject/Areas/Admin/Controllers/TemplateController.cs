using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TemplateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HeaderPartial()
        {
            return View();
        }

        public IActionResult LoaderPartial()
        {
            return View();
        }

        public IActionResult NavbarPartial()
        {
            return View();
        }

        public IActionResult RightbarPartial() // Mesajlar Bildirimler Mesaj Yazma
        {
            return View();
        }

        public IActionResult SidebarPartial()
        {
            return View();
        }

        public IActionResult ScriptPartial()
        {
            return View();
        }
    }
}
