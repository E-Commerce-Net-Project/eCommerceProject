using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ContactDtos;
using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ContactController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private IValidator<UpdateContactDto> _updateValidator;

        public ContactController(IMapper mapper, IValidator<UpdateContactDto> updateValidator, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _updateValidator = updateValidator;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult UpdateContact(int Id)
        {
            var values = _mapper.Map<UpdateContactDto>(_unitOfWork.ContactDal.GetByID(1));
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var validator = _updateValidator.Validate(updateContactDto);
            if (validator.IsValid)
            {
                var values = _mapper.Map<UpdateContactDto, Contact>(updateContactDto);
                _unitOfWork.ContactDal.Update(values);
                _unitOfWork.Commit();
                return View();
            }
            else
            {
                foreach (var item in validator.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View(updateContactDto);
            }

        }

    }
}