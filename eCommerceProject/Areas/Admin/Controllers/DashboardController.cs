using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

         public IActionResult StatisticsPartial()
        {
            return View();
        }

        public IActionResult SalesReportsPartial()
        {
            return View();
        }

		public IActionResult PageViewPartial()
		{
			return View();
		}

        public IActionResult OrderStatusPartial()
        {
            return View();

        }

        public IActionResult ProductValidationPartial()
        {
            return View();
        }

        public IActionResult SalesRevenuePartial()
        {
            return View();
        }

        public IActionResult ProductSummaryPartial()
        {
            return View();
        }

        public IActionResult BlancePartial()
        {
            return View();
        }
    }
}

