using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    { 
        private readonly IAboutService _aboutService;
        private readonly IMapper _mapper;
        private IValidator<UpdateAboutDto> _updateValidator;

        public AboutController (IAboutService aboutService, IMapper mapper, IValidator<UpdateAboutDto> updateValidator)
        {
            _aboutService = aboutService;
            _mapper = mapper;
            _updateValidator = updateValidator;
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id) 
        {
            #region Navbar Yönlendirmesi
            ViewBag.Title1 = "Hakkında Güncelleme Sayfası";
            ViewBag.Title2 = "Hakkında Sayfası";
            ViewBag.Title2Url = "/Admin/About/Index";
            ViewBag.Button = "Hakkında Sayfasına Dön";
            ViewBag.ButtonUrl = "/Admin/About/Index";
            #endregion

            var aboutValue= _mapper.Map<UpdateAboutDto>(_aboutService.TGeyByID(id));
            return View(aboutValue);
        }

        [HttpPost]
        public IActionResult UpdateAboutCategory(UpdateAboutDto updateAboutDto) 
        {
            #region Navbar Yönlendirmesi
            ViewBag.Title1 = "Hakkında Güncelleme Sayfası";
            ViewBag.Title2 = "Hakkında Sayfası";
            ViewBag.Title2Url = "/Admin/About/Index";
            ViewBag.Button = "Hakkında Sayfasına Dön";
            ViewBag.ButtonUrl = "/Admin/About/Index";
            #endregion

            var validator=_updateValidator.Validate(updateAboutDto);
            if (validator.IsValid)
            {
                var newAboutValue = _mapper.Map<UpdateAboutDto, About>(updateAboutDto);
                _aboutService.TUpdate(newAboutValue);
                return LocalRedirect("/Admin/About/Index");
            }
            else
            {
                foreach(var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName , item.ErrorMessage);
                }

                return View(updateAboutDto);
            }
        }
    }
}
