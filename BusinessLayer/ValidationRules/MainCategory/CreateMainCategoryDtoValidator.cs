﻿using DtoLayer.Dtos.MainCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.MainCategory
{
    public class CreateMainCategoryDtoValidator : AbstractValidator<CreateMainCategoryDto>
    {
        public CreateMainCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Ana kategori isim").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}