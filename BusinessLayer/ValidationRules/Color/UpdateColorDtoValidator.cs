using DtoLayer.Dtos.ColorDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Color
{
    public class UpdateColorDtoValidator : AbstractValidator<UpdateColorDto>
    {
        public UpdateColorDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Renk isim alanı boş geçilemez.").MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapınız.").MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
        }
    }
}
