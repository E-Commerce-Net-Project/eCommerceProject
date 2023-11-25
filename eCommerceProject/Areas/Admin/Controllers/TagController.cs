using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.GenreCategoryDtos;
using DtoLayer.Dtos.SponsorDtos;
using DtoLayer.Dtos.TagDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ITagService _tagService;
        private IValidator<CreateTagDto> _createValidator;
        private IValidator<UpdateTagDto> _updateValidator;

        public TagController(IValidator<CreateTagDto> createValidator, IValidator<UpdateTagDto> updateValidator, ITagService tagService, IMapper mapper)
        {
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _tagService = tagService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var tagValues = _tagService.TGetList();
            return View(tagValues.Data);
        }

        [HttpGet]
        public IActionResult AddTag()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddTag(CreateTagDto createTagDto)
        {
            var validator = _createValidator.Validate(createTagDto);

            if (validator.IsValid)
            {
                _tagService.TAdd(createTagDto);

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
            _tagService.TDelete(id);

            return LocalRedirect("/Admin/Tag/Index");
        }

        [HttpGet]
        public IActionResult UpdateTag(int id)
        {
            var tagValue = _tagService.TGetByID(id);
            var data = _mapper.Map<ResultTagDto, UpdateTagDto>(tagValue.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateTag(UpdateTagDto updateTagDto)
        {
            var validator = _updateValidator.Validate(updateTagDto);

            if (validator.IsValid)
            {
                _tagService.TUpdate(updateTagDto);

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
