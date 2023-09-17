using DtoLayer.Dtos.GenreCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.GenreCategory
{
    public class UpdateGenreCategoryDtoValidator : AbstractValidator<UpdateGenreCategoryDto>
    {
        public UpdateGenreCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Kategori türü isim").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}