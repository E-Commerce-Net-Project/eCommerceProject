using DtoLayer.Dtos.ContactDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Contact
{
    public class UpdateContactDtoValidator : AbstractValidator<UpdateContactDto>
    {
        public UpdateContactDtoValidator()
        {
            RuleFor(x => x.Adress).NotEmpty().WithMessage("Adres alanı boş geçilemez.").MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapınız.").MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail alanı boş geçilemez.").EmailAddress().WithMessage("Lütfen doğru mail adresi girişi yapınız.");
            RuleFor(x => x.OpeningHour).NotEmpty().WithMessage("Çalışma saatleri alanı boş geçilemez.");
            RuleFor(x => x.Iframe).NotEmpty().WithMessage("Harita url alanı boş geçilemez.");
        }
    }
}
