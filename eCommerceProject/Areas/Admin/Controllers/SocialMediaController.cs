using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ServiceDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SocialMediaController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateSocialMediaDto> _createValidator;
        private IValidator<UpdateSocialMediaDto> _updateValidator;

        public SocialMediaController(IMapper mapper, IValidator<CreateSocialMediaDto> createValidator, IValidator<UpdateSocialMediaDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var socialMediaValues = _mapper.Map<List<ResultSocialMediaDto>>(_unitOfWork.SocialMediaDal.GetList());
            return View(socialMediaValues);
        }

        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var validator = _createValidator.Validate(createSocialMediaDto);

            if (validator.IsValid)
            {
                var socialMediaValue = _mapper.Map<CreateSocialMediaDto, SocialMedia>(createSocialMediaDto);
                _unitOfWork.SocialMediaDal.Insert(socialMediaValue);
                _unitOfWork.Commit();

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
            var socialMediaID = _unitOfWork.SocialMediaDal.GetByID(id);
            _unitOfWork.SocialMediaDal.Delete(socialMediaID);
            _unitOfWork.Commit();
            return LocalRedirect("/Admin/SocialMedia/Index");
        }

        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var socialMediaValue = _mapper.Map<UpdateSocialMediaDto>(_unitOfWork.SocialMediaDal.GetByID(id));
            return View(socialMediaValue);
        }

        [HttpPost]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var validator = _updateValidator.Validate(updateSocialMediaDto);

            if (validator.IsValid)
            {
                var newSocialMediaValue = _mapper.Map<UpdateSocialMediaDto, SocialMedia>(updateSocialMediaDto);
                _unitOfWork.SocialMediaDal.Update(newSocialMediaValue);
                _unitOfWork.Commit();
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
