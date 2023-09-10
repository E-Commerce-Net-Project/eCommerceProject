﻿using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateColorDto> _createValidator;
        private IValidator<UpdateColorDto> _updateValidator;

        public ColorController(IMapper mapper, IValidator<CreateColorDto> createValidator, IValidator<UpdateColorDto> updateValidator, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
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
            var values = _mapper.Map<List<ResultColorDto>>(_unitOfWork.ColorDal.GetList());
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
                _unitOfWork.ColorDal.Insert(value);
                _unitOfWork.Commit();
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
            var values = _unitOfWork.ColorDal.GetByID(id);
            _unitOfWork.ColorDal.Delete(values);
            _unitOfWork.Commit();
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
            var values = _mapper.Map<UpdateColorDto>(_unitOfWork.ColorDal.GetByID(id));
            
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
                _unitOfWork.ColorDal.Update(values);
                _unitOfWork.Commit();

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
