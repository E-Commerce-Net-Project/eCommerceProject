using AutoMapper;
using BusinessLayer.ValidationRules.Product;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.ProductDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private IValidator<CreateProductDto> _createValidator;
        //private IValidator<UpdateGenreCategoryDto> _updateValidator;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper, IValidator<CreateProductDto> createValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _createValidator = createValidator;
        }

        public IActionResult Index()
        {
            var productValues = _mapper.Map<List<ResultProductDto>>(_unitOfWork.ProductDal.GetGenreCategoriesAndBrandsByProduct());
            return View(productValues);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult AddProduct(CreateProductDto createProductDto)
        //{
        //    var extension = Path.GetExtension(createProductDto.Image1.FileName);
        //    var newImageName = Guid.NewGuid() + extension;
        //    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/productimage/", newImageName);
        //    var stream = new FileStream(location, FileMode.Create);
        //    p.productimageurl1.CopyTo(stream);
        //    product.ImageUrl1Product = "/productimage/" + newImageName;

        //}
    }
}
