using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ContactUsDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SupportRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SupportRequestController(IMapper mapper, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Destek Talepleri";
            ViewBag.Title2 = "Mesajlar";
            //ViewBag.Title2Url = "/Admin/AdminRole/Index";
            ViewBag.Button = "Yeni Talep Cevapla";
			//ViewBag.ButtonUrl = "/Admin/AdminRole/AddRole";
			#endregion
			var messages = _mapper.Map<List<ResultContactUsDto>>(_unitOfWork.ContactUsDal.GetList());
			return View(messages);
        }

		[HttpGet]
		public IActionResult GetMessagesForCustomer(int customerId)
		{
			var customer = _mapper.Map<ResultContactUsDto>(_unitOfWork.ContactUsDal.GetByID(customerId));
			return Json(customer);
		}

	}
}
