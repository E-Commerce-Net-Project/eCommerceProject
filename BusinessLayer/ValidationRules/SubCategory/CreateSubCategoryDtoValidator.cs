using DtoLayer.Dtos.SubCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.SubCategory
{
    public class CreateSubCategoryDtoValidator : AbstractValidator<CreateSubCategoryDto>
    {
        public CreateSubCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Alt kategori isim alanı boş bırakılmamalıdır.").MinimumLength(5).WithMessage("Alt kategori ismi en az 5 karakter olmalıdır.").MaximumLength(50).WithMessage("Alt kategori ismi en fazla 50 karakter olmalıdır.");
        }
    }
}