using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BodySizeController: Controller
	{
		private readonly IBodySizeService _bodySizeService;
		private readonly IMapper _mapper;
		private IValidator<CreateBodySizeDto> _createValidator;
		private IValidator<UpdateBodySizeDto> _updateValidator;

		public BodySizeController (IBodySizeService bodySizeService, IMapper mapper , IValidator<CreateBodySizeDto> createValidator , IValidator<UpdateBodySizeDto> updateValidator)
		{
			_bodySizeService = bodySizeService;
			_mapper = mapper;
			_createValidator = createValidator;
			_updateValidator = updateValidator;
		}

		public IActionResult Index()
		{
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Beden listesi";
			ViewBag.Title2 = "Beden listesi";
			ViewBag.Title2Url = "/Admin/BodySize/Index";
			ViewBag.Button = "Yeni Beden Bilgisi Ekle";
			ViewBag.ButtonUrl = "/Admin/BodySize/AddBodySize";
            #endregion

            var bodySizeValues = _mapper.Map<List<ResultBodySizeDto>>(_bodySizeService.TGetList());
			return View(bodySizeValues);
		}

		[HttpGet]
		public IActionResult AddBodySize()
		{
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Yeni Beden Ekleme Sayfası";
            ViewBag.Title2 = "Beden listesi";
            ViewBag.Title2Url = "/Admin/BodySize/Index";
            ViewBag.Button = "Beden Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/BodySize/Index";
            #endregion

            return View();
		}

		[HttpPost]

		public IActionResult AddBodySize(CreateBodySizeDto createBodySizeDto)
		{
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Yeni Beden Ekleme Sayfası";
            ViewBag.Title2 = "Beden listesi";
            ViewBag.Title2Url = "/Admin/BodySize/Index";
            ViewBag.Button = "Beden Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/BodySize/Index";
            #endregion

            var validator =_createValidator.Validate(createBodySizeDto);
			if (validator.IsValid)
			{
				var bodySizeValue = _mapper.Map<CreateBodySizeDto, BodySize>(createBodySizeDto);
				_bodySizeService.TAdd(bodySizeValue);
				return LocalRedirect("/ Admin / BodySize / Index");

			}
			else
			{
				foreach (var item in validator.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}

				return View(createBodySizeDto);
			}

		}

		public IActionResult DeleteBodySize(int id)
		{
			var bodySizeID= _bodySizeService.TGeyByID(id);
			_bodySizeService.TDelete(bodySizeID);
			return LocalRedirect("/Admin/BodySize/Index");
		}

		[HttpGet]
		public IActionResult UpdateBodySize(int id)
		{
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Beden Bigisi Güncelleme Sayfası";
            ViewBag.Title2 = "Beden listesi";
            ViewBag.Title2Url = "/Admin/BodySize/Index";
            ViewBag.Button = "Beden Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/BodySize/Index";
            #endregion

            var bodySizeValue =_mapper.Map<UpdateBodySizeDto>(_bodySizeService.TGeyByID(id));
			return View(bodySizeValue);
		}

		[HttpPost]
		
		public IActionResult UpdateBodySize(UpdateBodySizeDto updateBodySizeDto)
		{
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Beden Bigisi Güncelleme Sayfası";
            ViewBag.Title2 = "Beden listesi";
            ViewBag.Title2Url = "/Admin/BodySize/Index";
            ViewBag.Button = "Beden Listesine Dön";
            ViewBag.ButtonUrl = "/Admin/BodySize/Index";
            #endregion

            var validator =_updateValidator.Validate(updateBodySizeDto);
			if (validator.IsValid)
			{
				var newBodySizeValue=_mapper.Map<UpdateBodySizeDto, BodySize>(updateBodySizeDto);
				_bodySizeService.TUpdate(newBodySizeValue);
				return LocalRedirect("/Admin/BodySize/Index");
			}
			else
			{
				foreach (var item in validator.Errors)
				{
					ModelState.AddModelError(item.PropertyName,item.ErrorMessage);
				}
				return View(updateBodySizeDto);
			}
		}

	}
}
