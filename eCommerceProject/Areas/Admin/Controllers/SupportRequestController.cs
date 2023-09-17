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
