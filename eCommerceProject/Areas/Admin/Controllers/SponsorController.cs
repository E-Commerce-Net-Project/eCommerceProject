using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.SocialMediaDtos;
using DtoLayer.Dtos.SponsorDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SponsorController : Controller
    {
        private readonly ISponsorService _sponsorService;
        private readonly IMapper _mapper;
        private IValidator<CreateSponsorDto> _createValidator;
        private IValidator<UpdateSponsorDto> _updateValidator;

        public SponsorController(ISponsorService sponsorService, IMapper mapper, IValidator<CreateSponsorDto> createValidator, IValidator<UpdateSponsorDto> updateValidator)
        {
            _sponsorService = sponsorService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sponsor";
            ViewBag.Title2 = "Sponsorlar";
            ViewBag.Title2Url = "/Admin/Sponsor/Index";
            ViewBag.Button = "Sponsor Ekle";
            ViewBag.ButtonUrl = "/Admin/Sponsor/AddSponsor";
            #endregion

            var sponsorValues = _mapper.Map<List<ResultSponsorDto>>(_sponsorService.TGetList());
            return View(sponsorValues);
        }

        [HttpGet]
        public IActionResult AddSponsor()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sponsor Ekleme Sayfası";
            ViewBag.Title2 = "Sponsorlar";
            ViewBag.Title2Url = "/Admin/Sponsor/Index";
            ViewBag.Button = "Sponsorlara Dön";
            ViewBag.ButtonUrl = "/Admin/Sponsor/Index";
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult AddSponsor(CreateSponsorDto createSponsorDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sponsor Ekleme Sayfası";
            ViewBag.Title2 = "Sponsorlar";
            ViewBag.Title2Url = "/Admin/Sponsor/Index";
            ViewBag.Button = "Sponsorlara Dön";
            ViewBag.ButtonUrl = "/Admin/Sponsor/Index";
            #endregion

            var validator = _createValidator.Validate(createSponsorDto);

            if (validator.IsValid)
            {
                var sponsorValue = _mapper.Map<CreateSponsorDto, Sponsor>(createSponsorDto);
                _sponsorService.TAdd(sponsorValue);

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
            var sponsorID = _sponsorService.TGeyByID(id);
            _sponsorService.TDelete(sponsorID);
            return LocalRedirect("/Admin/Sponsor/Index");
        }

        [HttpGet]
        public IActionResult UpdateSponsor(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sponsor Güncelleme Sayfası";
            ViewBag.Title2 = "Sponsorlar";
            ViewBag.Title2Url = "/Admin/Sponsor/Index";
            ViewBag.Button = "Sponsorlara Dön";
            ViewBag.ButtonUrl = "/Admin/Sponsor/Index";
            #endregion

            var sponsorValue = _mapper.Map<UpdateSponsorDto>(_sponsorService.TGeyByID(id));
            return View(sponsorValue);
        }

        [HttpPost]
        public IActionResult UpdateSponsor(UpdateSponsorDto updateSponsorDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sponsor Güncelleme Sayfası";
            ViewBag.Title2 = "Sponsorlar";
            ViewBag.Title2Url = "/Admin/Sponsor/Index";
            ViewBag.Button = "Sponsorlara Dön";
            ViewBag.ButtonUrl = "/Admin/Sponsor/Index";
            #endregion

            var validator = _updateValidator.Validate(updateSponsorDto);

            if (validator.IsValid)
            {
                var newSponsorValue = _mapper.Map<UpdateSponsorDto, Sponsor>(updateSponsorDto);
                _sponsorService.TUpdate(newSponsorValue);

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
