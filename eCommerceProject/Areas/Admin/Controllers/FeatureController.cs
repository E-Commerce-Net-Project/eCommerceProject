using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.FeatureDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FeatureController : Controller
    {

        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;
        private IValidator<CreateFeatureDto> _createValidator;
        private readonly IValidator<UpdateFeatureDto> _updateValidator;

        public FeatureController(IFeatureService featureService, IMapper mapper, IValidator<CreateFeatureDto> createValidator, IValidator<UpdateFeatureDto> updateValidator)
        {
            _featureService = featureService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Özellikler Listesi";
            ViewBag.Title2 = "Özellikler Listesi";
            ViewBag.Title2Url = "/Admin/Feature/Index";
            ViewBag.Button = "Yeni Özellik Ekle";
            ViewBag.ButtonUrl = "/Admin/Feature/AddFeature";
            #endregion
            var featureValues = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetList());
            return View(featureValues);
        }

        [HttpGet]
        public IActionResult AddFeature()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Özellik Ekleme Sayfası";
            ViewBag.Title2 = "Özellikler Listesi";
            ViewBag.Title2Url = "/Admin/Feature/Index";
            ViewBag.Button = "Özellik Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Feature/Index";
            #endregion
            return View();
        }

        [HttpPost]
        public IActionResult AddFeature(CreateFeatureDto createFeatureDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Özellik Ekleme Sayfası";
            ViewBag.Title2 = "Özellikler Listesi";
            ViewBag.Title2Url = "/Admin/Feature/Index";
            ViewBag.Button = "Özellik Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Feature/Index";
            #endregion

            var validator = _createValidator.Validate(createFeatureDto);
            if (validator.IsValid)
            {
                var featureValue = _mapper.Map<CreateFeatureDto, Feature>(createFeatureDto);
                _featureService.TAdd(featureValue);
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
            var featureID = _featureService.TGeyByID(id);
            _featureService.TDelete(featureID);
            return LocalRedirect("/Admin/Feature/Index");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Özellik Güncelleme Sayfası";
            ViewBag.Title2 = "Özellikler Listesi";
            ViewBag.Title2Url = "/Admin/Feature/Index";
            ViewBag.Button = "Özellik Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Feature/Index";
            #endregion
            var featureValue = _mapper.Map<UpdateFeatureDto>(_featureService.TGeyByID(id));
            return View(featureValue);
        }
        [HttpPost]
      
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Özellik Güncelleme Sayfası";
            ViewBag.Title2 = "Özellikler Listesi";
            ViewBag.Title2Url = "/Admin/Feature/Index";
            ViewBag.Button = "Özellik Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Feature/Index";
            #endregion
            var validator = _updateValidator.Validate(updateFeatureDto);
            if (validator.IsValid)
            {
                var newFeatureValue = _mapper.Map<UpdateFeatureDto, Feature>(updateFeatureDto);
                _featureService.TUpdate(newFeatureValue);
                return LocalRedirect("/Admin/Feature/Index");
            }
            else 
            {
                foreach(var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
                }
                return View(updateFeatureDto);
            }
        }


    }
}
