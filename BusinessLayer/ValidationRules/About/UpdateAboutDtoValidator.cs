using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoLayer.Dtos.AboutDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.About
{
    public class UpdateAboutDtoValidator : AbstractValidator <UpdateAboutDto>
    {
        public UpdateAboutDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama alanı boş geçilemez.");
        }

    }
}
