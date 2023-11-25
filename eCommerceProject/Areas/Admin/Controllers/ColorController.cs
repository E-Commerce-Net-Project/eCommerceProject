using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.ColorDtos;
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
    public class ColorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IColorService _colorService;
        private IValidator<CreateColorDto> _createValidator;
        private IValidator<UpdateColorDto> _updateValidator;

        public ColorController(IValidator<CreateColorDto> createValidator, IValidator<UpdateColorDto> updateValidator, IColorService colorService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _colorService = colorService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _colorService.TGetList();
            return View(values.Data);
        }

        [HttpGet]
        public IActionResult AddColor(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddColor(CreateColorDto createColorDto)
        {
            var validator = _createValidator.Validate(createColorDto);
            if (validator.IsValid)
            {
                _colorService.TAdd(createColorDto);
                
                return LocalRedirect("/Admin/Color/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(createColorDto);
            }

        }

        public IActionResult DeleteColor(int id)
        {
            
            _colorService.TDelete(id);
            return LocalRedirect("/Admin/Color/Index");
        }

        [HttpGet]
        public IActionResult UpdateColor(int id)
        {
            var values = _colorService.TGetByID(id);
            var data = _mapper.Map<ResultColorDto, UpdateColorDto>(values.Data);
            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateColor(UpdateColorDto updateColorDto)
        {
            var validator = _updateValidator.Validate(updateColorDto);
            if (validator.IsValid)
            {
                

                //buraya if'le result.Success ise veya değilse diye döngü yapılabilir.
                var result = _colorService.TUpdate(updateColorDto);
                

                return LocalRedirect("/Admin/Color/Index");


            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateColorDto);
            }
        }
    }
}
