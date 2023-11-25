using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BrandDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IBrandService _brandService;
        private IValidator<CreateBrandDto> _createValidator;
        private IValidator<UpdateBrandDto> _updateValidator;

        public BrandController(IValidator<CreateBrandDto> createValidator, IValidator<UpdateBrandDto> updateValidator, IBrandService brandService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _brandService = brandService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _brandService.TGetList();
            return View(values.Data);
        }

        [HttpGet]
        public IActionResult AddBrand(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(CreateBrandDto createBrandDto)
        {
            var validator = _createValidator.Validate(createBrandDto);
            if (validator.IsValid)
            {
                _brandService.TAdd(createBrandDto);
                return LocalRedirect("/Admin/Brand/Index");

            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,
                      item.ErrorMessage);

                }
                return View(createBrandDto);
            }

        }

        public IActionResult DeleteBrand(int id)
        {
            _brandService.TDelete(id);
            return LocalRedirect("/Admin/Brand/Index");

        }

        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            var value = _brandService.TGetByID(id);
            var data = _mapper.Map<ResultBrandDto, UpdateBrandDto>(value.Data);
            return View(data);
        }
        public IActionResult UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var validator = _updateValidator.Validate(updateBrandDto);
            if (validator.IsValid)
            {
                _brandService.TUpdate(updateBrandDto);
                return LocalRedirect("/Admin/Brand/Index");
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateBrandDto);
            }

        }
    }
}
