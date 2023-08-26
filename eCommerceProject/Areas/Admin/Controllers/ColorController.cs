using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ColorController : Controller
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        private IValidator<CreateColorDto> _createValidator;
        private IValidator<UpdateColorDto> _updateValidator;

        public ColorController(IColorService colorService, IMapper mapper, IValidator<CreateColorDto> createValidator, IValidator<UpdateColorDto> updateValidator)
        {
            _colorService = colorService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Renk Listesi";
            ViewBag.Title2 = "Renk Listesi";
            ViewBag.Title2Url = "/Admin/Color/Index";
            ViewBag.Button = "Yeni Renk Ekle";
            ViewBag.ButtonUrl = "/Admin/Color/AddColor";
            #endregion
            var values = _mapper.Map<List<ResultColorDto>>(_colorService.TGetList());
           return View(values);
        }
        [HttpGet]
        public IActionResult AddColor(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Renk Ekleme Sayfası";
            ViewBag.Title2 = "Renk Listesi";
            ViewBag.Title2Url = "/Admin/Color/Index";
            ViewBag.Button = "Renk Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Color/Index";
            #endregion
            
            return View();
        }

        [HttpPost]
        public IActionResult AddColor(CreateColorDto createColorDto) 
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Renk Ekleme Sayfası";
            ViewBag.Title2 = "Renk Listesi";
            ViewBag.Title2Url = "/Admin/Color/Index";
            ViewBag.Button = "Renk Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Color/Index";
            #endregion

            var validator = _createValidator.Validate(createColorDto);
            if (validator.IsValid)
            {
                var value = _mapper.Map<CreateColorDto, Color>(createColorDto);
                _colorService.TAdd(value);
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
            var values = _colorService.TGeyByID(id);
            _colorService.TDelete(values);
            return LocalRedirect("/Admin/Color/Index");
        }

        [HttpGet]
        public IActionResult UpdateColor(int id) 
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Renk Güncelleme Sayfası";
            ViewBag.Title2 = "Renk Listesi";
            ViewBag.Title2Url = "/Admin/Color/Index";
            ViewBag.Button = "Renk Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Color/Index";
            #endregion
            var values = _mapper.Map<UpdateColorDto>(_colorService.TGeyByID(id));
            
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateColor(UpdateColorDto updateColorDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Renk Güncelleme Sayfası";
            ViewBag.Title2 = "Renk Listesi";
            ViewBag.Title2Url = "/Admin/Color/Index";
            ViewBag.Button = "Renk Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/Color/Index";
            #endregion

            var validator =_updateValidator.Validate(updateColorDto);
            if (validator.IsValid)
            {
                var values = _mapper.Map<UpdateColorDto,Color>(updateColorDto);
                _colorService.TUpdate(values);

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
