using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ContactDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<UpdateContactDto> _updateValidator;

        public ContactController(IMapper mapper, IValidator<UpdateContactDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "İletşim Bilgileri";
            ViewBag.Title2 = "İletişim Bilgileri";
            ViewBag.Title2Url = "/Admin/Contact/Index";
            ViewBag.Button = "Güncelle";
            ViewBag.ButtonUrl = "/Admin/Contact/Index";
            #endregion

            var values = _mapper.Map<UpdateContactDto>(_unitOfWork.ContactDal.GetByID(id=1));

            return View(values);
        }

        [HttpPost]
        public IActionResult Index( UpdateContactDto updateContactDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "İletşim Bilgileri";
            ViewBag.Title2 = "İletişim Bilgileri";
            ViewBag.Title2Url = "/Admin/Contact/Index";
            ViewBag.Button = "Güncelle";
            ViewBag.ButtonUrl = "/Admin/Contact/Index";
            #endregion

            var validator = _updateValidator.Validate(updateContactDto);
            if (validator.IsValid)
            {
                var values = _mapper.Map<UpdateContactDto, Contact>(updateContactDto);
                _unitOfWork.ContactDal.Update(values);
                _unitOfWork.Commit();
                return LocalRedirect("/Admin/Contact/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(updateContactDto);
            }

        }

    }
}
