using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.AboutDtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        
        private readonly IMapper _mapper;
        private IValidator<UpdateAboutDto> _updateValidator;

        public AboutController(IMapper mapper, IValidator<UpdateAboutDto> updateValidator, IAboutService aboutService)
        {
            _mapper = mapper;
            _updateValidator = updateValidator;
            
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var aboutValue = _aboutService.TGetByID(1);
            var newAboutValue = _mapper.Map<ResultAboutDto, UpdateAboutDto>(aboutValue.Data);

            return View(newAboutValue);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var validator = _updateValidator.Validate(updateAboutDto);
            if (validator.IsValid)
            {
                //var newAboutValue = _mapper.Map<UpdateAboutDto, About>(updateAboutDto);
                //_aboutService.TUpdate(newAboutValue);
                //_unitOfWork.AboutDal.Update(newAboutValue);
                //_unitOfWork.Commit();
                _aboutService.TUpdate(updateAboutDto);
                return LocalRedirect("/Admin/About/UpdateAbout");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateAboutDto);
            }
        }
    }
}
