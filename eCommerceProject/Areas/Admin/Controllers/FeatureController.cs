using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
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

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateFeatureDto> _createValidator;
        private readonly IValidator<UpdateFeatureDto> _updateValidator;

        public FeatureController(IMapper mapper, IValidator<CreateFeatureDto> createValidator, IValidator<UpdateFeatureDto> updateValidator, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
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
            var featureValues = _mapper.Map<List<ResultFeatureDto>>(_unitOfWork.FeatureDal.GetList());
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
                _unitOfWork.FeatureDal.Insert(featureValue);
                _unitOfWork.Commit();
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
            var featureID = _unitOfWork.FeatureDal.GetByID(id);
            _unitOfWork.FeatureDal.Delete(featureID);
            _unitOfWork.Commit();
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
            var featureValue = _mapper.Map<UpdateFeatureDto>(_unitOfWork.FeatureDal.GetByID(id));
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
                _unitOfWork.FeatureDal.Update(newFeatureValue);
                _unitOfWork.Commit();
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
