using DtoLayer.Dtos.SubCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.SubCategory
{
    public class UpdateSubCategoryDtoValidator : AbstractValidator<UpdateSubCategoryDto>
    {
        public UpdateSubCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithName("Alt kategori isim").WithMessage(ValidationMessages.NotEmpty).MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage).MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }
    }
}