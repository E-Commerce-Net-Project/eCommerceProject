using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.ContactUsDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupportRequestController : Controller
    {
		private readonly IContactUsService _contactUsService;
		private readonly IMapper _mapper;
		public SupportRequestController(IContactUsService contactUsService, IMapper mapper)
		{
			_contactUsService = contactUsService;
			_mapper = mapper;
		}

		public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Destek Talepleri";
            ViewBag.Title2 = "Mesajlar";
            //ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Yeni Destek Talebi";
			//ViewBag.ButtonUrl = "/Admin/AdminRole/AddRole";
			#endregion
			var messages = _mapper.Map<List<ResultContactUsDto>>(_contactUsService.TGetList());
			return View(messages);
        }

		[HttpGet]
		public IActionResult GetMessagesForCustomer(int customerId)
		{
			var customer = _mapper.Map<ResultContactUsDto>(_contactUsService.TGeyByID(customerId));
			return Json(customer);
		}

	}
}
