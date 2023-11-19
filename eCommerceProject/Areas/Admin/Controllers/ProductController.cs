using AutoMapper;
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

            createProductDto.CoverImage = imageHelper.SaveImage(addProductImageModel.coverImage);
            createProductDto.Image1 = imageHelper.SaveImage(addProductImageModel.Image1);
            createProductDto.Image2 = imageHelper.SaveImage(addProductImageModel.Image2);
            createProductDto.Image3 = imageHelper.SaveImage(addProductImageModel.Image3);
            createProductDto.Image4 = imageHelper.SaveImage(addProductImageModel.Image4);
            createProductDto.Image5 = imageHelper.SaveImage(addProductImageModel.Image5);

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

            var productValue = _mapper.Map<CreateProductDto, Product>(createProductDto);
            _unitOfWork.ProductDal.Insert(productValue);
            _unitOfWork.Commit();

            return LocalRedirect("/Admin/Product/Index");
        }

        [HttpGet]
        public IActionResult UpdateProduct(int id)
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

            var productValue = _mapper.Map<UpdateProductDto>(_unitOfWork.ProductDal.GetByID(id));

            return View(productValue);
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

            var newProductValue = _mapper.Map<UpdateProductDto, Product>(updateProductDto);
            _unitOfWork.ProductDal.Update(newProductValue);
            _unitOfWork.Commit();

            return LocalRedirect("/Admin/Product/Index");
        }

        public IActionResult ChangeProductStatus(int id)
        {
            _unitOfWork.ProductDal.ChangeStatus(id);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/Product/Index");
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.ProductDal.GetByID(id);
            _unitOfWork.ProductDal.Delete(product);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/Product/Index");
        }
    }
}