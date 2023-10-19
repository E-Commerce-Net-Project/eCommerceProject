using AutoMapper;
using BusinessLayer.ValidationRules.Product;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.ProductDtos;
using eCommerceProject.Areas.Admin.Models;
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
            var resource = Directory.GetCurrentDirectory();
            var extension = Path.GetExtension(addProductImageModel.coverImage.FileName);
            var imagename = Guid.NewGuid() + extension;
            var savelocation = resource + "/wwwroot/ProductImages/" + imagename;
            var stream = new FileStream(savelocation, FileMode.Create);
            await addProductImageModel.coverImage.CopyToAsync(stream);
            createProductDto.CoverImage = "/ProductImages/" + imagename;

            var resource1 = Directory.GetCurrentDirectory();
            var extension1 = Path.GetExtension(addProductImageModel.Image1.FileName);
            var imagename1 = Guid.NewGuid() + extension1;
            var savelocation1 = resource1 + "/wwwroot/ProductImages/" + imagename1;
            var stream1 = new FileStream(savelocation1, FileMode.Create);
            await addProductImageModel.Image1.CopyToAsync(stream1);
            createProductDto.Image1 = "/ProductImages/" + imagename;

            var resource2 = Directory.GetCurrentDirectory();
            var extension2 = Path.GetExtension(addProductImageModel.Image2.FileName);
            var imagename2 = Guid.NewGuid() + extension2;
            var savelocation2 = resource2 + "/wwwroot/ProductImages/" + imagename2;
            var stream2 = new FileStream(savelocation2, FileMode.Create);
            await addProductImageModel.Image2.CopyToAsync(stream2);
            createProductDto.Image2 = "/ProductImages/" + imagename;

            var resource3 = Directory.GetCurrentDirectory();
            var extension3 = Path.GetExtension(addProductImageModel.Image3.FileName);
            var imagename3 = Guid.NewGuid() + extension3;
            var savelocation3 = resource3 + "/wwwroot/ProductImages/" + imagename3;
            var stream3 = new FileStream(savelocation3, FileMode.Create);
            await addProductImageModel.Image3.CopyToAsync(stream3);
            createProductDto.Image3 = "/ProductImages/" + imagename;

            var resource4 = Directory.GetCurrentDirectory();
            var extension4 = Path.GetExtension(addProductImageModel.Image4.FileName);
            var imagename4 = Guid.NewGuid() + extension4;
            var savelocation4 = resource4 + "/wwwroot/ProductImages/" + imagename4;
            var stream4 = new FileStream(savelocation4, FileMode.Create);
            await addProductImageModel.Image4.CopyToAsync(stream4);
            createProductDto.Image4 = "/ProductImages/" + imagename;

            var resource5 = Directory.GetCurrentDirectory();
            var extension5 = Path.GetExtension(addProductImageModel.Image5.FileName);
            var imagename5 = Guid.NewGuid() + extension5;
            var savelocation5 = resource5 + "/wwwroot/ProductImages/" + imagename5;
            var stream5 = new FileStream(savelocation5, FileMode.Create);
            await addProductImageModel.Image5.CopyToAsync(stream5);
            createProductDto.Image5 = "/ProductImages/" + imagename;


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

            return LocalRedirect("/Admin/Product/Index");
        }
    }
}