using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MainCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateMainCategoryDto> _createValidator;
        private IValidator<UpdateMainCategoryDto> _updateValidator;

        public MainCategoryController(IMapper mapper, IValidator<CreateMainCategoryDto> createValidator, IValidator<UpdateMainCategoryDto> updateValidator, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
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

            var mainCategoryValues = _mapper.Map<List<ResultMainCategoryDto>>(_unitOfWork.MainCategoryDal.GetList());
            return View(mainCategoryValues);
        }

        [HttpGet]
        public IActionResult AddMainCategory()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Ana Kategori Ekleme Sayfası";
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
            ViewBag.Title1 = "Ana Kategori Ekleme Sayfası";
            ViewBag.Title2 = "Ana Kategoriler";
            ViewBag.Title2Url = "/Admin/MainCategory/Index";
            ViewBag.Button = "Ana Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/MainCategory/Index";
            #endregion

            var validator = _createValidator.Validate(createMainCategoryDto);

            if (validator.IsValid)
            {
                var mainCategoryValue = _mapper.Map<CreateMainCategoryDto, MainCategory>(createMainCategoryDto);
                _unitOfWork.MainCategoryDal.Insert(mainCategoryValue);

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
            var categoryID = _unitOfWork.MainCategoryDal.GetByID(id);
            _unitOfWork.MainCategoryDal.Delete(categoryID);
            _unitOfWork.Commit();
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

            var mainCategoryValue = _mapper.Map<UpdateMainCategoryDto>(_unitOfWork.MainCategoryDal.GetByID(id));
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
                _unitOfWork.MainCategoryDal.Update(newMainCategoryValue);
                _unitOfWork.Commit();   

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