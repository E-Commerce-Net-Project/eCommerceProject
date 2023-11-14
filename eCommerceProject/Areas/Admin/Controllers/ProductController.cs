using AutoMapper;
using BusinessLayer.ValidationRules.Product;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.ProductDtos;
using eCommerceProject.Areas.Admin.Models;
using eCommerceProject.Helpers;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

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
            List<SelectListItem> BrandName = (from x in _unitOfWork.BrandDal.GetList()
                                              select new SelectListItem
                                              {
                                                  Text = x.Name,
                                                  Value = x.ID.ToString()
                                              }).ToList();
            ViewBag.brandName = BrandName;

            List<SelectListItem> GenreCategoryName = (from x in _unitOfWork.GenreCategoryDal.GetList()
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

            IFormFile[] imageFiles = new IFormFile[]
            {
                addProductImageModel.coverImage,
                addProductImageModel.Image1,
                addProductImageModel.Image2,
                addProductImageModel.Image3,
                addProductImageModel.Image4,
                addProductImageModel.Image5
            };

            createProductDto.CoverImage = createProductDto.CoverImage; // İlk resmi kapak resmi olarak atadık.


            for (int i = 0; i < imageFiles.Length - 1; i++)
            {
                createProductDto.GetType().GetProperty($"Image{i + 1}")?.SetValue(createProductDto, imageHelper.SaveImage(imageFiles[i]));
            }


            List<SelectListItem> GenreCategoryName = (from x in _unitOfWork.GenreCategoryDal.GetList()
                                                      select new SelectListItem
                                                      {
                                                          Text = x.Name,
                                                          Value = x.ID.ToString()
                                                      }).ToList();
            ViewBag.genreCategoryName = GenreCategoryName;

            var productValue = _mapper.Map<CreateProductDto, Product>(createProductDto);
            _unitOfWork.ProductDal.Insert(productValue);
            _unitOfWork.Commit();

            return LocalRedirect("/Admin/Product/Index");
        }
    }
}