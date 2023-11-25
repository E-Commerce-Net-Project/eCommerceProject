using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.SubCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IMapper _mapper;   
        private readonly IMainCategoryService _mainCategoryService;
        private readonly ISubCategoryService _subCategoryService;
        private IValidator<CreateSubCategoryDto> _createValidator;
        private IValidator<UpdateSubCategoryDto> _updateValidator;

        public SubCategoryController(IValidator<CreateSubCategoryDto> createValidator, IValidator<UpdateSubCategoryDto> updateValidator, IMainCategoryService mainCategoryService, ISubCategoryService subCategoryService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mainCategoryService = mainCategoryService;
            _subCategoryService = subCategoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var subCategoryValues = _subCategoryService.TSubCategoriesListWithMainCategory();
            return View(subCategoryValues.Data);
        }

        [HttpGet]
        public IActionResult AddSubCategory()
        {
            List<SelectListItem> MainCategoryName = (from x in _mainCategoryService.TGetList().Data
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
            var validator = _createValidator.Validate(createSubCategoryDto);

            if (validator.IsValid)
            {
                List<SelectListItem> MainCategoryName = (from x in _mainCategoryService.TGetList().Data
                                                         select new SelectListItem
                                                         {
                                                             Text = x.Name,
                                                             Value = x.ID.ToString()
                                                         }).ToList();
                ViewBag.mainCategoryName = MainCategoryName;

                _subCategoryService.TAdd(createSubCategoryDto);

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
            _subCategoryService.TDelete(id);
            return LocalRedirect("/Admin/SubCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateSubCategory(int id)
        {
            List<SelectListItem> MainCategoryName = (from x in _mainCategoryService.TGetList().Data
                                                     select new SelectListItem
                                                     {
                                                         Text = x.Name,
                                                         Value = x.ID.ToString()
                                                     }).ToList();
            ViewBag.mainCategoryName = MainCategoryName;

            var subCategoryValue = _subCategoryService.TGetByID(id);
            var data = _mapper.Map<ResultSubCategoryDto, UpdateSubCategoryDto>(subCategoryValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateSubCategory(UpdateSubCategoryDto updateSubCategoryDto)
        {
            var validator = _updateValidator.Validate(updateSubCategoryDto);

            if (validator.IsValid)
            {
                _subCategoryService.TUpdate(updateSubCategoryDto);

                return LocalRedirect("/Admin/SubCategory/Index");
            }

            else
            {
                List<SelectListItem> MainCategoryName = (from x in _mainCategoryService.TGetList().Data
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
