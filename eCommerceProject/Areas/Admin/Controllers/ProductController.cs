using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.ProductDtos;
using eCommerceProject.Areas.Admin.Models;
using eCommerceProject.Helpers;
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
        private readonly IMapper _mapper;   
        private readonly IProductService _productService;   
        private readonly IGenreCategoryService _genreCategoryService;
        private readonly IBrandService _brandService;

        private IValidator<CreateProductDto> _createValidator;
        //private IValidator<UpdateGenreCategoryDto> _updateValidator;

        public ProductController(IValidator<CreateProductDto> createValidator, IBrandService brandService, IGenreCategoryService genreCategoryService, IProductService productService, IMapper mapper)
        {
            _createValidator = createValidator;
            _brandService = brandService;
            _genreCategoryService = genreCategoryService;
            _productService = productService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var productValues = _productService.TGetGenreCategoriesAndBrandsByProduct();
            return View(productValues.Data);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            List<SelectListItem> BrandName = (from x in _brandService.TGetList().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.brandName = BrandName;

            List<SelectListItem> GenreCategoryName = (from x in _genreCategoryService.TGetList().Data
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.ID.ToString()
                                                      }).ToList();
            ViewBag.genreCategoryName = GenreCategoryName;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto createProductDto, AddProductImageModel addProductImageModel)
        {
            var imageHelper = new ImageHelper(Directory.GetCurrentDirectory());

            createProductDto.CoverImage = imageHelper.SaveImage(addProductImageModel.coverImage);
            createProductDto.Image1 = imageHelper.SaveImage(addProductImageModel.Image1);
            createProductDto.Image2 = imageHelper.SaveImage(addProductImageModel.Image2);
            createProductDto.Image3 = imageHelper.SaveImage(addProductImageModel.Image3);
            createProductDto.Image4 = imageHelper.SaveImage(addProductImageModel.Image4);
            createProductDto.Image5 = imageHelper.SaveImage(addProductImageModel.Image5);

            List<SelectListItem> BrandName = (from x in _brandService.TGetList().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.brandName = BrandName;

            List<SelectListItem> GenreCategoryName = (from x in _genreCategoryService.TGetList().Data
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.ID.ToString()
                                                      }).ToList();
            ViewBag.genreCategoryName = GenreCategoryName;

            _productService.TAdd(createProductDto);

            return LocalRedirect("/Admin/Product/Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            List<SelectListItem> BrandName = (from x in _brandService.TGetList().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.brandName = BrandName;

            List<SelectListItem> GenreCategoryName = (from x in _genreCategoryService.TGetList().Data
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.ID.ToString()
                                                      }).ToList();
            ViewBag.genreCategoryName = GenreCategoryName;

            var productValue = _productService.TGetByID(id);
            var data = _mapper.Map<ResultProductDto, UpdateProductDto>(productValue.Data);

            return View(data);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto, AddProductImageModel addProductImageModel)
        {
            var imageHelper = new ImageHelper(Directory.GetCurrentDirectory());

            updateProductDto.CoverImage = imageHelper.SaveImage(addProductImageModel.coverImage);
            updateProductDto.Image1 = imageHelper.SaveImage(addProductImageModel.Image1);
            updateProductDto.Image2 = imageHelper.SaveImage(addProductImageModel.Image2);
            updateProductDto.Image3 = imageHelper.SaveImage(addProductImageModel.Image3);
            updateProductDto.Image4 = imageHelper.SaveImage(addProductImageModel.Image4);
            updateProductDto.Image5 = imageHelper.SaveImage(addProductImageModel.Image5);

            List<SelectListItem> BrandName = (from x in _brandService.TGetList().Data
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.brandName = BrandName;

            List<SelectListItem> GenreCategoryName = (from x in _genreCategoryService.TGetList().Data
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.ID.ToString()
                                                      }).ToList();
            ViewBag.genreCategoryName = GenreCategoryName;

            _productService.TUpdate(updateProductDto);

            return LocalRedirect("/Admin/Product/Index");
        }

        public IActionResult ChangeProductStatus(int id)
        {
            _productService.TChangeStatus(id);
            return LocalRedirect("/Admin/Product/Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            _productService.TDelete(id);
            return LocalRedirect("/Admin/Product/Index");
        }
    }
}