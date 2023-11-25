using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.UoW;
using DtoLayer.Dtos.ColorDtos;
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
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        private IValidator<UpdateContactDto> _updateValidator;

        public ContactController(IMapper mapper, IValidator<UpdateContactDto> updateValidator, IContactService contactService)
        {
            _mapper = mapper;
            _updateValidator = updateValidator;
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult UpdateContact(int Id)
        {
            var values = _contactService.TGetByID(1);
            var data = _mapper.Map<ResultContactDto, UpdateContactDto>(values.Data);

            return View(data);
        }

        [HttpPost]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var validator = _updateValidator.Validate(updateContactDto);
            if (validator.IsValid)
            {
                _contactService.TUpdate(updateContactDto);
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