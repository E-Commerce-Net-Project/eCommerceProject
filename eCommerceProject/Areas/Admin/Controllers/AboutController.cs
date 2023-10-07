using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<UpdateAboutDto> _updateValidator;

        public AboutController(IMapper mapper, IValidator<UpdateAboutDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            var aboutValue = _mapper.Map<UpdateAboutDto>(_unitOfWork.AboutDal.GetByID(1));
            return View(aboutValue);
        }

        [HttpPost]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var validator = _updateValidator.Validate(updateAboutDto);
            if (validator.IsValid)
            {
                var newAboutValue = _mapper.Map<UpdateAboutDto, About>(updateAboutDto);
                //_aboutService.TUpdate(newAboutValue);
                _unitOfWork.AboutDal.Update(newAboutValue);
                _unitOfWork.Commit();
                return View();
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
