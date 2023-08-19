using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainCategoryController : Controller
    {
        private readonly IMainCategoryService _mainCategoryService;
        private readonly IMapper _mapper;
        private IValidator<CreateMainCategoryDto> _createValidator;
        private IValidator<UpdateMainCategoryDto> _updateValidator;

        public MainCategoryController(IMainCategoryService mainCategoryService, IMapper mapper, IValidator<CreateMainCategoryDto> createValidator, IValidator<UpdateMainCategoryDto> updateValidator)
        {
            _mainCategoryService = mainCategoryService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Ana Kategoriler";
            ViewBag.Title2 = "Ana Kategoriler";
            ViewBag.Title2Url = "/Admin/MainCategory/Index";
            ViewBag.Button = "Yeni Ana Kategori Ekle";
            ViewBag.ButtonUrl = "/Admin/MainCategory/AddMainCategory";
            #endregion

            var mainCategoryValues = _mapper.Map<List<ResultMainCategoryDto>>(_mainCategoryService.TGetList());
            return View(mainCategoryValues);
        }

        [HttpGet]
        public IActionResult AddMainCategory()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Ana Kategoriler Ekleme Sayfası";
            ViewBag.Title2 = "Ana Kategoriler";
            ViewBag.Title2Url = "/Admin/MainCategory/Index";
            ViewBag.Button = "Ana Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/MainCategory/Index";
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult AddMainCategory(CreateMainCategoryDto createMainCategoryDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Ana Kategoriler Ekleme Sayfası";
            ViewBag.Title2 = "Ana Kategoriler";
            ViewBag.Title2Url = "/Admin/MainCategory/Index";
            ViewBag.Button = "Ana Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/MainCategory/Index";
            #endregion

            var validator = _createValidator.Validate(createMainCategoryDto);

            if (validator.IsValid)
            {
                var mainCategoryValue = _mapper.Map<CreateMainCategoryDto, MainCategory>(createMainCategoryDto);
                _mainCategoryService.TAdd(mainCategoryValue);

                return LocalRedirect("/Admin/MainCategory/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createMainCategoryDto);
            }
        }

        public IActionResult DeleteMainCategory(int id)
        {
            var categoryID = _mainCategoryService.TGeyByID(id);
            _mainCategoryService.TDelete(categoryID);
            return LocalRedirect("/Admin/MainCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateMainCategory(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Ana Kategori Güncelleme Sayfası";
            ViewBag.Title2 = "Ana Kategoriler";
            ViewBag.Title2Url = "/Admin/MainCategory/Index";
            ViewBag.Button = "Ana Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/MainCategory/Index";
            #endregion

            var mainCategoryValue = _mapper.Map<UpdateMainCategoryDto>(_mainCategoryService.TGeyByID(id));
            return View(mainCategoryValue);
        }

        [HttpPost]
        public IActionResult UpdateMainCategory(UpdateMainCategoryDto updateMainCategoryDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Ana Kategori Güncelleme Sayfası";
            ViewBag.Title2 = "Ana Kategoriler";
            ViewBag.Title2Url = "/Admin/MainCategory/Index";
            ViewBag.Button = "Ana Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/MainCategory/Index";
            #endregion

            var validator = _updateValidator.Validate(updateMainCategoryDto);

            if (validator.IsValid)
            {
                var newMainCategoryValue = _mapper.Map<UpdateMainCategoryDto, MainCategory>(updateMainCategoryDto);
                _mainCategoryService.TUpdate(newMainCategoryValue);

                return LocalRedirect("/Admin/MainCategory/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateMainCategoryDto);
            }
        }
    }
}