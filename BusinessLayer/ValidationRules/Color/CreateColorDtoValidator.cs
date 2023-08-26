using DtoLayer.Dtos.ColorDtos;
using DtoLayer.Dtos.MainCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Color
{
    public class CreateColorDtoValidator : AbstractValidator<CreateColorDto>
    {
        public CreateColorDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Renk isim alanı boş geçilemez.").MinimumLength(2).WithMessage("Lütfen en az iki karakter girişi yapınız.").MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter girişi yapınız");
        }
    }
}
