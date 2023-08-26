using AutoMapper;
using BusinessLayer.Abstract;

using DtoLayer.Dtos.ContactDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private IValidator<UpdateContactDto> _updateValidator;

        public ContactController(IContactService contactService, IMapper mapper, IValidator<UpdateContactDto> updateValidator)
        {
            _contactService = contactService;
            _mapper = mapper;
            _updateValidator = updateValidator;
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

            var values = _mapper.Map<UpdateContactDto>(_contactService.TGeyByID(id=1));

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
