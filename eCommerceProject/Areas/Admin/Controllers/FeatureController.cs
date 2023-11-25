using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.FeatureDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class FeatureController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IFeatureService _featureService;
        private IValidator<CreateFeatureDto> _createValidator;
        private readonly IValidator<UpdateFeatureDto> _updateValidator;

        public FeatureController(IValidator<CreateFeatureDto> createValidator, IValidator<UpdateFeatureDto> updateValidator, IFeatureService featureService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _featureService = featureService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var featureValues = _featureService.TGetList();
            return View(featureValues.Data);
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDto createFeatureDto)
        {
            var validator = _createValidator.Validate(createFeatureDto);
            if (validator.IsValid)
            {
                _featureService.TAdd(createFeatureDto);
                return LocalRedirect("/Admin/Feature/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createFeatureDto);
            }
        }

        public IActionResult DeleteFeature(int id)
        {
            _featureService.TDelete(id);
            return LocalRedirect("/Admin/Feature/Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var featureValue = _featureService.TGetByID(id);
            var data = _mapper.Map<ResultFeatureDto, UpdateFeatureDto>(featureValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var validator = _updateValidator.Validate(updateFeatureDto);
            if (validator.IsValid)
            {
                _featureService.TUpdate(updateFeatureDto);
                return LocalRedirect("/Admin/Feature/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(updateFeatureDto);
            }
        }
    }
}
