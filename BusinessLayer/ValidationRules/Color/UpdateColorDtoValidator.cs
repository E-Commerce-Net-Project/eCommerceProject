﻿using DtoLayer.Dtos.ColorDtos;
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
            RuleFor(x => x.Name).NotEmpty().WithName("Renk isim").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}
