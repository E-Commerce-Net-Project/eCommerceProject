using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.ServiceDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IMapper _mapper;
        private IValidator<CreateServiceDto> _createValidator;
        private IValidator<UpdateServiceDto> _updateValidator;

        public ServiceController(IValidator<CreateServiceDto> createValidator, IValidator<UpdateServiceDto> updateValidator, IServiceService serviceService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _serviceService = serviceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var serviceValues = _serviceService.TGetList();
            return View(serviceValues.Data);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddService(CreateServiceDto createServiceDto)
        {
            var validator = _createValidator.Validate(createServiceDto);

            if (validator.IsValid)
            {
                _serviceService.TAdd(createServiceDto);

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
            _serviceService.TDelete(id);
            return LocalRedirect("/Admin/Service/Index");
        }

        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            var serviceValue = _serviceService.TGetByID(id);
            var data = _mapper.Map<ResultServiceDto, UpdateServiceDto>(serviceValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateService(UpdateServiceDto updateServiceDto)
        {
            var validator = _updateValidator.Validate(updateServiceDto);

            if (validator.IsValid)
            {
                _serviceService.TUpdate(updateServiceDto);

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
