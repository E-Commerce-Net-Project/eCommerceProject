using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.BodySizeDtos;
using DtoLayer.Dtos.BrandDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BodySizeController: Controller
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private IValidator<CreateBodySizeDto> _createValidator;
		private IValidator<UpdateBodySizeDto> _updateValidator;

        public BodySizeController(IMapper mapper, IValidator<CreateBodySizeDto> createValidator, IValidator<UpdateBodySizeDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
		{
            var bodySizeValues = _mapper.Map<List<ResultBodySizeDto>>(_unitOfWork.BodySizeDal.GetList());
			return View(bodySizeValues);
		}

		[HttpGet]
		public IActionResult AddBodySize()
		{
            return View();
		}

		[HttpPost]

		public IActionResult AddBodySize(CreateBodySizeDto createBodySizeDto)
		{
            var validator =_createValidator.Validate(createBodySizeDto);
			if (validator.IsValid)
			{
				var bodySizeValue = _mapper.Map<CreateBodySizeDto, BodySize>(createBodySizeDto);
				_unitOfWork.BodySizeDal.Insert(bodySizeValue);
				_unitOfWork.Commit();	
				return LocalRedirect("/Admin/BodySize/Index");

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
			var bodySizeID= _unitOfWork.BodySizeDal.GetByID(id);
			_unitOfWork.BodySizeDal.Delete(bodySizeID);
			return LocalRedirect("/Admin/BodySize/Index");
		}

		[HttpGet]
		public IActionResult UpdateBodySize(int id)
		{
            var bodySizeValue =_mapper.Map<UpdateBodySizeDto>(_unitOfWork.BodySizeDal.GetByID(id));
			return View(bodySizeValue);
		}

		[HttpPost]
		
		public IActionResult UpdateBodySize(UpdateBodySizeDto updateBodySizeDto)
		{
            var validator =_updateValidator.Validate(updateBodySizeDto);
			if (validator.IsValid)
			{
				var newBodySizeValue=_mapper.Map<UpdateBodySizeDto, BodySize>(updateBodySizeDto);
				_unitOfWork.BodySizeDal.Update(newBodySizeValue);
				_unitOfWork.Commit();
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
