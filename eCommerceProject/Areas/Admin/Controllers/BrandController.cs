using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BrandDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly  IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateBrandDto> _createValidator;
        private IValidator<UpdateBrandDto> _updateValidator;

        public BrandController(IMapper mapper, IValidator<CreateBrandDto> createValidator, IValidator<UpdateBrandDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }


        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Marka Listesi";
            ViewBag.Title2 = "Marka Listesi";
            ViewBag.Title2Url = "/Admin/Brand/Index";
            ViewBag.Button = "Yeni Marka Ekle";
            ViewBag.ButtonUrl = "/Admin/Brand/AddBrand";

            #endregion
            var values = _mapper.Map < List<ResultBrandDto>>(_unitOfWork.BrandDal.GetList());
            return View(values);
        }

        [HttpGet]
            public IActionResult AddBrand(int id)
            {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Marka Ekleme Sayfası";
            ViewBag.Title2 = "Marka Listesi";
            ViewBag.Title2Url = "/Admin/Brand/Index";
            ViewBag.Button = "Marka Listesine Geri Dön";
            ViewBag.ButtonUrl = "/Admin/Brand/Index";

            #endregion

            return View();
            }

        [HttpPost]
        public IActionResult AddBrand(CreateBrandDto createBrandDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Marka Ekleme Sayfası";
            ViewBag.Title2 = "Marka Listesi";
            ViewBag.Title2Url = "/Admin/Brand/Index";
            ViewBag.Button = "Marka Listesine Geri Dön";
            ViewBag.ButtonUrl = "/Admin/Brand/Index";
            #endregion

            var validator = _createValidator.Validate(createBrandDto);
            if (validator.IsValid) 
            {
                var value = _mapper.Map<CreateBrandDto, Brand>(createBrandDto);
                _unitOfWork.BrandDal.Insert(value);
                _unitOfWork.Commit();
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
            var values = _unitOfWork.BrandDal.GetByID(id);
            _unitOfWork.BrandDal.Delete(values);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/Brand/Index");

        }

        [HttpGet]
        public IActionResult UpdateBrand(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Marka Güncelleme Sayfası";
            ViewBag.Title2 = "Marka Listesi";
            ViewBag.Title2Url = "/Admin/Brand/Index";
            ViewBag.Button = "Marka Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Brand/Index";
            #endregion

            var values = _mapper.Map<UpdateBrandDto>(_unitOfWork.BrandDal.GetByID(id));
            return View(values);
        }
        public IActionResult UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Marka Güncelleme Sayfası";
            ViewBag.Title2 = "Marka Listesi";
            ViewBag.Title2Url = "/Admin/Brand/Index";
            ViewBag.Button = "Marka Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Brand/Index";
            #endregion
            var validator = _updateValidator.Validate(updateBrandDto);
            if (validator.IsValid) 
            {
                var values = _mapper.Map<UpdateBrandDto,Brand>(updateBrandDto);
                _unitOfWork.BrandDal.Update(values);
                _unitOfWork.Commit();
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
