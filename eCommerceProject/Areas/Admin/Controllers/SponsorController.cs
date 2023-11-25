using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using DtoLayer.Dtos.SponsorDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SponsorController : Controller
    {
        private readonly ISponsorService _sponsorService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateSponsorDto> _createValidator;
        private IValidator<UpdateSponsorDto> _updateValidator;

        public SponsorController(IMapper mapper, IValidator<CreateSponsorDto> createValidator, IValidator<UpdateSponsorDto> updateValidator, IUnitOfWork unitOfWork, ISponsorService sponsorService)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
            _sponsorService = sponsorService;
        }

        public IActionResult Index()
        {
            var sponsorValues = _sponsorService.TGetList();
            return View(sponsorValues.Data);
        }

        [HttpGet]
        public IActionResult AddSponsor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSponsor(CreateSponsorDto createSponsorDto)
        {
            var validator = _createValidator.Validate(createSponsorDto);

            if (validator.IsValid)
            {
                _sponsorService.TAdd(createSponsorDto);

                return LocalRedirect("/Admin/Sponsor/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createSponsorDto);
            }
        }

        public IActionResult DeleteSponsor(int id)
        {
            _sponsorService.TDelete(id);

            return LocalRedirect("/Admin/Sponsor/Index");
        }

        [HttpGet]
        public IActionResult UpdateSponsor(int id)
        {
            var sponsorValue = _sponsorService.TGetByID(id);
            var data = _mapper.Map<ResultSponsorDto, UpdateSponsorDto>(sponsorValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateSponsor(UpdateSponsorDto updateSponsorDto)
        {
            var validator = _updateValidator.Validate(updateSponsorDto);

            if (validator.IsValid)
            {
                _sponsorService.TUpdate(updateSponsorDto);

                return LocalRedirect("/Admin/Sponsor/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateSponsorDto);
            }
        }
    }
}
