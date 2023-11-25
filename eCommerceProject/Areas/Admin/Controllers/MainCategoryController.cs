using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class MainCategoryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IMainCategoryService _mainCategoryService;
        private IValidator<CreateMainCategoryDto> _createValidator;
        private IValidator<UpdateMainCategoryDto> _updateValidator;

        public MainCategoryController(IValidator<CreateMainCategoryDto> createValidator, IValidator<UpdateMainCategoryDto> updateValidator, IMainCategoryService mainCategoryService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _mainCategoryService = mainCategoryService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var mainCategoryValues = _mainCategoryService.TGetList();
            return View(mainCategoryValues.Data);
        }

        [HttpGet]
        public IActionResult AddMainCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddMainCategory(CreateMainCategoryDto createMainCategoryDto)
        {
            var validator = _createValidator.Validate(createMainCategoryDto);

            if (validator.IsValid)
            {
                _mainCategoryService.TAdd(createMainCategoryDto);

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
            _mainCategoryService.TDelete(id);
            return LocalRedirect("/Admin/MainCategory/Index");
        }

        [HttpGet]
        public IActionResult UpdateMainCategory(int id)
        {
            var mainCategoryValue = _mainCategoryService.TGetByID(id);
            var data = _mapper.Map<ResultMainCategoryDto, UpdateMainCategoryDto>(mainCategoryValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateMainCategory(UpdateMainCategoryDto updateMainCategoryDto)
        {
            var validator = _updateValidator.Validate(updateMainCategoryDto);

            if (validator.IsValid)
            {
                _mainCategoryService.TUpdate(updateMainCategoryDto);

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