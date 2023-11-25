using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.ServiceDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private IValidator<CreateSocialMediaDto> _createValidator;
        private IValidator<UpdateSocialMediaDto> _updateValidator;

        public SocialMediaController(IValidator<CreateSocialMediaDto> createValidator, IValidator<UpdateSocialMediaDto> updateValidator, ISocialMediaService socialMediaService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var socialMediaValues = _socialMediaService.TGetList();
            return View(socialMediaValues.Data);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var validator = _createValidator.Validate(createSocialMediaDto);

            if (validator.IsValid)
            {
                _socialMediaService.TAdd(createSocialMediaDto);

                return LocalRedirect("/Admin/SocialMedia/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createSocialMediaDto);
            }
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            _socialMediaService.TDelete(id);
            return LocalRedirect("/Admin/SocialMedia/Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMediaValue = _socialMediaService.TGetByID(id);
            var data = _mapper.Map<ResultSocialMediaDto, UpdateSocialMediaDto>(socialMediaValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var validator = _updateValidator.Validate(updateSocialMediaDto);

            if (validator.IsValid)
            {
                _socialMediaService.TUpdate(updateSocialMediaDto);
                return LocalRedirect("/Admin/SocialMedia/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateSocialMediaDto);
            }
        }
    }
}
