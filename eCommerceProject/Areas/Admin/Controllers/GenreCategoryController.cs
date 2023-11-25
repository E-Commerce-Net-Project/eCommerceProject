using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.GenreCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class GenreCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IGenreCategoryService _genreCategoryService;
        private IValidator<CreateGenreCategoryDto> _createValidator;
        private IValidator<UpdateGenreCategoryDto> _updateValidator;

        public GenreCategoryController(IValidator<CreateGenreCategoryDto> createValidator, IValidator<UpdateGenreCategoryDto> updateValidator, ISubCategoryService subCategoryService, IGenreCategoryService genreCategoryService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _subCategoryService = subCategoryService;
            _genreCategoryService = genreCategoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var genreCategoryValues = _genreCategoryService.TGenreCategoriesListWithSubCategory();
            return View(genreCategoryValues.Data);
        }

        [HttpGet]
        public IActionResult AddGenreCategory()
        {
            List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList().Data
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.subCategoryName = SubCategoryName;

            return View();
        }

        [HttpPost]
        public IActionResult AddGenreCategory(CreateGenreCategoryDto createGenreCategoryDto)
        {
            var validator = _createValidator.Validate(createGenreCategoryDto);

            if (validator.IsValid)
            {
                List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList().Data
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ID.ToString()
                                                        }).ToList();
                ViewBag.subCategoryName = SubCategoryName;

                _genreCategoryService.TAdd(createGenreCategoryDto);

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
            _genreCategoryService.TDelete(id);
            return LocalRedirect("/Admin/GenreCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateGenreCategory(int id)
        {
            List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList().Data
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.ID.ToString()
                                                    }).ToList();
            ViewBag.subCategoryName = SubCategoryName;

            var genreCategoryValue = _genreCategoryService.TGetByID(id);
            var data = _mapper.Map<ResultGenreCategoryDto, UpdateGenreCategoryDto>(genreCategoryValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateGenreCategory(UpdateGenreCategoryDto updateGenreCategoryDto)
        {
            var validator = _updateValidator.Validate(updateGenreCategoryDto);

            if (validator.IsValid)
            {
                _genreCategoryService.TUpdate(updateGenreCategoryDto);

                return LocalRedirect("/Admin/GenreCategory/Index");
            }

            else
            {
                List<SelectListItem> SubCategoryName = (from x in _subCategoryService.TGetList().Data
                                                        select new SelectListItem
                                                        {
                                                            Text = x.Name,
                                                            Value = x.ID.ToString()
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
