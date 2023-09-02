using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DtoLayer.Dtos.GenreCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GenreCategoryController : Controller
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly IGenreCategoryService _genreCategoryService;
        private readonly IMapper _mapper;
        private IValidator<CreateGenreCategoryDto> _createValidator;
        private IValidator<UpdateGenreCategoryDto> _updateValidator;

        public GenreCategoryController(IGenreCategoryService genreCategoryService, IMapper mapper, IValidator<CreateGenreCategoryDto> createValidator, IValidator<UpdateGenreCategoryDto> updateValidator, ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
            _genreCategoryService = genreCategoryService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }
        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kategori Türleri";
            ViewBag.Title2 = "Kategori Türleri";
            ViewBag.Title2Url = "/Admin/GenreCategory/Index";
            ViewBag.Button = "Yeni Kategori Türü Ekle";
            ViewBag.ButtonUrl = "/Admin/GenreCategory/AddGenreCategory";
            #endregion

            var genreCategoryValues = _mapper.Map<List<ResultGenreCategoryDto>>(_genreCategoryService.TGenreCategoriesListWithSubCategory());
            return View(genreCategoryValues);
        }

        [HttpGet]
        public IActionResult AddGenreCategory()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kategori Türü Ekleme Sayfası";
            ViewBag.Title2 = "Kategori Türleri";
            ViewBag.Title2Url = "/Admin/GenreCategory/Index";
            ViewBag.Button = "Kategori Türlerine Dön";
            ViewBag.ButtonUrl = "/Admin/GenreCategory/Index";
            #endregion

            List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.SubCategoryID.ToString()
                                                    }).ToList();
            ViewBag.subCategoryName = SubCategoryName;

            return View();
        }

        [HttpPost]
        public IActionResult AddGenreCategory(CreateGenreCategoryDto createGenreCategoryDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kategori Türü Ekleme Sayfası";
            ViewBag.Title2 = "Kategori Türleri";
            ViewBag.Title2Url = "/Admin/GenreCategory/Index";
            ViewBag.Button = "Kategori Türlerine Dön";
            ViewBag.ButtonUrl = "/Admin/GenreCategory/Index";
            #endregion

            var validator = _createValidator.Validate(createGenreCategoryDto);

            if (validator.IsValid)
            {
                List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.SubCategoryID.ToString()
                                                        }).ToList();
                ViewBag.subCategoryName = SubCategoryName;

                var genreCategoryValue = _mapper.Map<CreateGenreCategoryDto, GenreCategory>(createGenreCategoryDto);
                _genreCategoryService.TAdd(genreCategoryValue);

                return LocalRedirect("/Admin/GenreCategory/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createGenreCategoryDto);
            }
        }

        public IActionResult DeleteGenreCategory(int id)
        {
            var categoryID = _genreCategoryService.TGeyByID(id);
            _genreCategoryService.TDelete(categoryID);
            return LocalRedirect("/Admin/GenreCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateGenreCategory(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kategori Türü Güncelleme Sayfası";
            ViewBag.Title2 = "Kategori Türleri";
            ViewBag.Title2Url = "/Admin/GenreCategory/Index";
            ViewBag.Button = "Kategori Türlerine Dön";
            ViewBag.ButtonUrl = "/Admin/GenreCategory/Index";
            #endregion

            List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList()
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.SubCategoryID.ToString()
                                                    }).ToList();
            ViewBag.subCategoryName = SubCategoryName;

            var genreCategoryValue = _mapper.Map<UpdateGenreCategoryDto>(_genreCategoryService.TGeyByID(id));
            return View(genreCategoryValue);
        }

        [HttpPost]
        public IActionResult UpdateGenreCategory(UpdateGenreCategoryDto updateGenreCategoryDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Kategori Türü Güncelleme Sayfası";
            ViewBag.Title2 = "Kategori Türleri";
            ViewBag.Title2Url = "/Admin/GenreCategory/Index";
            ViewBag.Button = "Kategori Türlerine Dön";
            ViewBag.ButtonUrl = "/Admin/GenreCategory/Index";
            #endregion

            var validator = _updateValidator.Validate(updateGenreCategoryDto);

            if (validator.IsValid)
            {
                var newGenreCategoryValue = _mapper.Map<UpdateGenreCategoryDto, GenreCategory>(updateGenreCategoryDto);
                _genreCategoryService.TUpdate(newGenreCategoryValue);

                return LocalRedirect("/Admin/GenreCategory/Index");
            }

            else
            {
                List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList()
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.SubCategoryID.ToString()
                                                        }).ToList();
                ViewBag.subCategoryName = SubCategoryName;

                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateGenreCategoryDto);
            }
        }
    }
}
