using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ContactUsDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SupportRequestController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IContactUsService _contactUsService;
        public SupportRequestController(IMapper mapper, IUnitOfWork unitOfWork, IContactUsService contactUsService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _contactUsService = contactUsService;
        }

        public IActionResult Index()
        {
            //var messages = _mapper.Map<List<ResultContactUsDto>>(_unitOfWork.ContactUsDal.GetList());
            var result = _contactUsService.TGetList();
            return View(result.Data);
        }

        [HttpGet]
        public IActionResult GetMessagesForCustomer(int customerId)
        {
            var customer = _mapper.Map<ResultContactUsDto>(_unitOfWork.ContactUsDal.GetByID(customerId));
            return Json(customer);
        }
    }
}
