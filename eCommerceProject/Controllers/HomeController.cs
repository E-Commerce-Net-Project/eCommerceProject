using eCommerceProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eCommerceProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public IActionResult Index() 
        {
            return View();
        }


        
    }
}