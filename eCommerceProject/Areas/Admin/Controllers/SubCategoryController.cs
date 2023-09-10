using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.SubCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateSubCategoryDto> _createValidator;
        private IValidator<UpdateSubCategoryDto> _updateValidator;

        public SubCategoryController(IMapper mapper, IValidator<CreateSubCategoryDto> createValidator, IValidator<UpdateSubCategoryDto> updateValidator, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Alt Kategoriler";
            ViewBag.Title2 = "Alt Kategoriler";
            ViewBag.Title2Url = "/Admin/SubCategory/Index";
            ViewBag.Button = "Yeni Alt Kategori Ekle";
            ViewBag.ButtonUrl = "/Admin/SubCategory/AddSubCategory";
            #endregion

            var subCategoryValues = _mapper.Map<List<ResultSubCategoryDto>>(_unitOfWork.SubCategoryDal.SubCategoriesListWithMainCategory());
            return View(subCategoryValues);
        }

        [HttpGet]
        public IActionResult AddSubCategory()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Alt Kategori Ekleme Sayfası";
            ViewBag.Title2 = "Alt Kategoriler";
            ViewBag.Title2Url = "/Admin/SubCategory/Index";
            ViewBag.Button = "Alt Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/SubCategory/Index";
            #endregion

            List<SelectListItem> MainCategoryName = (from x in _unitOfWork.MainCategoryDal.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.ID.ToString()
                                                     }).ToList();
            ViewBag.mainCategoryName = MainCategoryName;

            return View();
        }

        [HttpPost]
        public IActionResult AddSubCategory(CreateSubCategoryDto createSubCategoryDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Alt Kategori Ekleme Sayfası";
            ViewBag.Title2 = "Alt Kategoriler";
            ViewBag.Title2Url = "/Admin/SubCategory/Index";
            ViewBag.Button = "Alt Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/SubCategory/Index";
            #endregion

            var validator = _createValidator.Validate(createSubCategoryDto);

            if (validator.IsValid)
            {
                List<SelectListItem> MainCategoryName = (from x in _unitOfWork.MainCategoryDal.GetList()
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.ID.ToString()
                                                         }).ToList();
                ViewBag.mainCategoryName = MainCategoryName;

                var subCategoryValue = _mapper.Map<CreateSubCategoryDto, SubCategory>(createSubCategoryDto);
                _unitOfWork.SubCategoryDal.Insert(subCategoryValue);
                _unitOfWork.Commit();

                return LocalRedirect("/Admin/SubCategory/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createSubCategoryDto);
            }
        }

        public IActionResult DeleteSubCategory(int id)
        {
            var categoryID = _unitOfWork.SubCategoryDal.GetByID(id);
            _unitOfWork.SubCategoryDal.Delete(categoryID);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/SubCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateSubCategory(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Alt Kategori Güncelleme Sayfası";
            ViewBag.Title2 = "Alt Kategoriler";
            ViewBag.Title2Url = "/Admin/SubCategory/Index";
            ViewBag.Button = "Alt Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/SubCategory/Index";
            #endregion

            List<SelectListItem> MainCategoryName = (from x in _unitOfWork.MainCategoryDal.GetList()
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.ID.ToString()
                                                     }).ToList();
            ViewBag.mainCategoryName = MainCategoryName;

            var subCategoryValue = _mapper.Map<UpdateSubCategoryDto>(_unitOfWork.SubCategoryDal.GetByID(id));
            return View(subCategoryValue);
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(UpdateSubCategoryDto updateSubCategoryDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Alt Kategori Güncelleme Sayfası";
            ViewBag.Title2 = "Alt Kategoriler";
            ViewBag.Title2Url = "/Admin/SubCategory/Index";
            ViewBag.Button = "Alt Kategorilere Dön";
            ViewBag.ButtonUrl = "/Admin/SubCategory/Index";
            #endregion

            var validator = _updateValidator.Validate(updateSubCategoryDto);

            if (validator.IsValid)
            {
                var newSubCategoryValue = _mapper.Map<UpdateSubCategoryDto, SubCategory>(updateSubCategoryDto);
                _unitOfWork.SubCategoryDal.Update(newSubCategoryValue);
                _unitOfWork.Commit();   

                return LocalRedirect("/Admin/SubCategory/Index");
            }

            else
            {
                List<SelectListItem> MainCategoryName = (from x in _unitOfWork.MainCategoryDal.GetList()
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.ID.ToString()
                                                         }).ToList();
                ViewBag.mainCategoryName = MainCategoryName;

                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateSubCategoryDto);
            }
        }
    }
}
