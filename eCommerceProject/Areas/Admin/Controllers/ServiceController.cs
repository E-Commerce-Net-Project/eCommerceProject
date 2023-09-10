﻿using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ServiceDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateServiceDto> _createValidator;
        private IValidator<UpdateServiceDto> _updateValidator;

        public ServiceController(IMapper mapper, IValidator<CreateServiceDto> createValidator, IValidator<UpdateServiceDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Hizmetler";
            ViewBag.Title2 = "Hizmetler";
            ViewBag.Title2Url = "/Admin/Service/Index";
            ViewBag.Button = "Yeni Hizmet Ekle";
            ViewBag.ButtonUrl = "/Admin/Service/AddService";
            #endregion

            var serviceValues = _mapper.Map<List<ResultServiceDto>>(_unitOfWork.ServiceDal.GetList());
            return View(serviceValues);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Hizmet Ekleme Sayfası";
            ViewBag.Title2 = "Hizmetler";
            ViewBag.Title2Url = "/Admin/Service/Index";
            ViewBag.Button = "Hizmetlere Dön";
            ViewBag.ButtonUrl = "/Admin/Service/Index";
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult AddService(CreateServiceDto createServiceDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Hizmet Ekleme Sayfası";
            ViewBag.Title2 = "Hizmetler";
            ViewBag.Title2Url = "/Admin/Service/Index";
            ViewBag.Button = "Hizmetlere Dön";
            ViewBag.ButtonUrl = "/Admin/Service/Index";
            #endregion

            var validator = _createValidator.Validate(createServiceDto);

            if (validator.IsValid)
            {
                var serviceValue = _mapper.Map<CreateServiceDto, Service>(createServiceDto);
                _unitOfWork.ServiceDal.Insert(serviceValue);
                _unitOfWork.Commit();

                return LocalRedirect("/Admin/Service/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createServiceDto);
            }
        }

        public IActionResult DeleteService(int id)
        {
            var serviceID = _unitOfWork.ServiceDal.GetByID(id);
            _unitOfWork.ServiceDal.Delete(serviceID);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/Service/Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Hizmet Güncelleme Sayfası";
            ViewBag.Title2 = "Hizmetler";
            ViewBag.Title2Url = "/Admin/Service/Index";
            ViewBag.Button = "Hizmetlere Dön";
            ViewBag.ButtonUrl = "/Admin/Service/Index";
            #endregion

            var serviceValue = _mapper.Map<UpdateServiceDto>(_unitOfWork.ServiceDal.GetByID(id));
            return View(serviceValue);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Hizmet Güncelleme Sayfası";
            ViewBag.Title2 = "Hizmetler";
            ViewBag.Title2Url = "/Admin/Service/Index";
            ViewBag.Button = "Hizmetlere Dön";
            ViewBag.ButtonUrl = "/Admin/Service/Index";
            #endregion

            var validator = _updateValidator.Validate(updateServiceDto);

            if (validator.IsValid)
            {
                var newServiceValue = _mapper.Map<UpdateServiceDto, Service>(updateServiceDto);
                _unitOfWork.ServiceDal.Update(newServiceValue);
                _unitOfWork.Commit();

                return LocalRedirect("/Admin/Service/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateServiceDto);
            }
        }
    }
}
