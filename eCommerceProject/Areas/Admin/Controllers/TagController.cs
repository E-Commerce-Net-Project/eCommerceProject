using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.SponsorDtos;
using DtoLayer.Dtos.TagDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TagController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<CreateTagDto> _createValidator;
        private IValidator<UpdateTagDto> _updateValidator;

        public TagController(IMapper mapper, IValidator<CreateTagDto> createValidator, IValidator<UpdateTagDto> updateValidator, IUnitOfWork unitOfWork)
        {

            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Etiket";
            ViewBag.Title2 = "Etiketler";
            ViewBag.Title2Url = "/Admin/Tag/Index";
            ViewBag.Button = "Yeni Etiket Ekle";
            ViewBag.ButtonUrl = "/Admin/Tag/AddTag";
            #endregion

            var tagValues = _mapper.Map<List<ResultTagDto>>(_unitOfWork.TagDal.GetList());
            return View(tagValues);
        }

        [HttpGet]
        public IActionResult AddTag()
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Etiket Ekleme Sayfası";
            ViewBag.Title2 = "Etiketler";
            ViewBag.Title2Url = "/Admin/Tag/Index";
            ViewBag.Button = "Etiketlere Dön";
            ViewBag.ButtonUrl = "/Admin/Tag/Index";
            #endregion

            return View();
        }

        [HttpPost]
        public IActionResult AddTag(CreateTagDto createTagDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Etiket Ekleme Sayfası";
            ViewBag.Title2 = "Etiketler";
            ViewBag.Title2Url = "/Admin/Tag/Index";
            ViewBag.Button = "Etiketlere Dön";
            ViewBag.ButtonUrl = "/Admin/Tag/Index";
            #endregion

            var validator = _createValidator.Validate(createTagDto);

            if (validator.IsValid)
            {
                var tagValue = _mapper.Map<CreateTagDto, Tag>(createTagDto);
                _unitOfWork.TagDal.Insert(tagValue);
                _unitOfWork.Commit();

                return LocalRedirect("/Admin/Tag/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(createTagDto);
            }
        }

        public IActionResult DeleteTag(int id)
        {
            var tagID = _unitOfWork.TagDal.GetByID(id);
            _unitOfWork.TagDal.Delete(tagID);
            _unitOfWork.Commit();

            return LocalRedirect("/Admin/Tag/Index");
        }

        [HttpGet]
        public IActionResult UpdateTag(int id)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Etiket Güncelleme Sayfası";
            ViewBag.Title2 = "Etiketler";
            ViewBag.Title2Url = "/Admin/Tag/Index";
            ViewBag.Button = "Etiketlere Dön";
            ViewBag.ButtonUrl = "/Admin/Tag/Index";
            #endregion

            var tagValue = _mapper.Map<UpdateTagDto>(_unitOfWork.TagDal.GetByID(id));
            return View(tagValue);
        }

        [HttpPost]
        public IActionResult UpdateTag(UpdateTagDto updateTagDto)
        {
            #region Navbar Yönlendirme
            ViewBag.Title1 = "Etiket Güncelleme Sayfası";
            ViewBag.Title2 = "Etiketler";
            ViewBag.Title2Url = "/Admin/Tag/Index";
            ViewBag.Button = "Etiketlere Dön";
            ViewBag.ButtonUrl = "/Admin/Tag/Index";
            #endregion

            var validator = _updateValidator.Validate(updateTagDto);

            if (validator.IsValid)
            {
                var newTagValue = _mapper.Map<UpdateTagDto, Tag>(updateTagDto);
                _unitOfWork.TagDal.Update(newTagValue);
                _unitOfWork.Commit();


                return LocalRedirect("/Admin/Tag/Index");
            }

            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View(updateTagDto);
            }
        }
    }
}
