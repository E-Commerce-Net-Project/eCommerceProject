using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Controllers
{
    [AllowAnonymous]
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            ViewBag.Code = code;
            
            return View();
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
