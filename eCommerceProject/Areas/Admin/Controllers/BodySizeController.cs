using AutoMapper;
using BusinessLayer.Abstract;
using DtoLayer.Dtos.BodySizeDtos;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class BodySizeController: Controller
	{
		private readonly IBodySizeService _bodySizeService;
		private readonly IMapper _mapper;
		private IValidator<CreateBodySizeDto> _createValidator;
		private IValidator<UpdateBodySizeDto> _updateValidator;

        public BodySizeController(IMapper mapper, IValidator<CreateBodySizeDto> createValidator, IValidator<UpdateBodySizeDto> updateValidator,  IBodySizeService bodySizeService)
        {
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _bodySizeService = bodySizeService;
        }

        public IActionResult Index()
		{
            var bodySizeValues = _bodySizeService.TGetList();
			return View(bodySizeValues.Data);
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
				//var bodySizeValue = _mapper.Map<CreateBodySizeDto, BodySize>(createBodySizeDto);
				//_unitOfWork.BodySizeDal.Insert(bodySizeValue);
				//_unitOfWork.Commit();	
				var result = _bodySizeService.TAdd(createBodySizeDto);
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
			//var bodySizeID= _unitOfWork.BodySizeDal.GetByID(id);
			//_unitOfWork.BodySizeDal.Delete(bodySizeID);
			_bodySizeService.TDelete(id);
			return LocalRedirect("/Admin/BodySize/Index");
		}

		[HttpGet]
		public IActionResult UpdateBodySize(int id)
		{
            var bodySizeValue =_bodySizeService.TGetByID(id);
            var newBodySizeValue = _mapper.Map<ResultBodySizeDto, UpdateBodySizeDto>(bodySizeValue.Data);
            var data= newBodySizeValue;	
			
			
			return View(data);
		}

		[HttpPost]
		
		public IActionResult UpdateBodySize(UpdateBodySizeDto updateBodySizeDto)
		{
            var validator =_updateValidator.Validate(updateBodySizeDto);
			if (validator.IsValid)
			{
				//var newBodySizeValue=_mapper.Map<UpdateBodySizeDto, BodySize>(updateBodySizeDto);
				//_unitOfWork.BodySizeDal.Update(newBodySizeValue);
				//_unitOfWork.Commit();
				_bodySizeService.TUpdate(updateBodySizeDto);
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
