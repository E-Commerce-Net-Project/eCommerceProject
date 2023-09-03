using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.ServiceDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;
        private IValidator<CreateSocialMediaDto> _createValidator;
        private IValidator<UpdateSocialMediaDto> _updateValidator;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper, IValidator<CreateSocialMediaDto> createValidator, IValidator<UpdateSocialMediaDto> updateValidator)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sosyal Medya";
            ViewBag.Title2 = "Sosyal Medyalar";
            ViewBag.Title2Url = "/Admin/SocialMedia/Index";
            ViewBag.Button = "Sosyal Medya Ekle";
            ViewBag.ButtonUrl = "/Admin/SocialMedia/AddSocialMedia";
            #endregion

            var socialMediaValues = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetList());
            return View(socialMediaValues);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sosyal Medya Ekleme Sayfası";
            ViewBag.Title2 = "Sosyal Medyalar";
            ViewBag.Title2Url = "/Admin/SocialMedia/Index";
            ViewBag.Button = "Sosyal Medyaya Dön";
            ViewBag.ButtonUrl = "/Admin/SocialMedia/Index";
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sosyal Medya Ekleme Sayfası";
            ViewBag.Title2 = "Sosyal Medyalar";
            ViewBag.Title2Url = "/Admin/SocialMedia/Index";
            ViewBag.Button = "Sosyal Medyaya Dön";
            ViewBag.ButtonUrl = "/Admin/SocialMedia/Index";
            #endregion

            var validator = _createValidator.Validate(createSocialMediaDto);

            if (validator.IsValid)
            {
                var socialMediaValue = _mapper.Map<CreateSocialMediaDto, SocialMedia>(createSocialMediaDto);
                _socialMediaService.TAdd(socialMediaValue);

                return LocalRedirect("/Admin/SocialMedia/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createSocialMediaDto);
            }
        }

        public IActionResult DeleteSocialMedia(int id)
        {
            var socialMediaID = _socialMediaService.TGeyByID(id);
            _socialMediaService.TDelete(socialMediaID);
            return LocalRedirect("/Admin/SocialMedia/Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sosyal Medya Güncelleme Sayfası";
            ViewBag.Title2 = "Sosyal Medyalar";
            ViewBag.Title2Url = "/Admin/SocialMedia/Index";
            ViewBag.Button = "Sosyal Medyaya Dön";
            ViewBag.ButtonUrl = "/Admin/SocialMedia/Index";
            #endregion

            var socialMediaValue = _mapper.Map<UpdateSocialMediaDto>(_socialMediaService.TGeyByID(id));
            return View(socialMediaValue);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Sosyal Medya Güncelleme Sayfası";
            ViewBag.Title2 = "Sosyal Medyalar";
            ViewBag.Title2Url = "/Admin/SocialMedia/Index";
            ViewBag.Button = "Sosyal Medyaya Dön";
            ViewBag.ButtonUrl = "/Admin/SocialMedia/Index";
            #endregion

            var validator = _updateValidator.Validate(updateSocialMediaDto);

            if (validator.IsValid)
            {
                var newSocialMediaValue = _mapper.Map<UpdateSocialMediaDto, SocialMedia>(updateSocialMediaDto);
                _socialMediaService.TUpdate(newSocialMediaValue);

                return LocalRedirect("/Admin/SocialMedia/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateSocialMediaDto);
            }
        }
    }
}
