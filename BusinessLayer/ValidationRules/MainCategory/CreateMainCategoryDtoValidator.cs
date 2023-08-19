using DtoLayer.Dtos.MainCategoryDtos;
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
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ana kategori isim alanı boş bırakılmamalıdır.").MinimumLength(5).WithMessage("Ana kategori ismi en az 5 karakter olmalıdır.").MaximumLength(50).WithMessage("Ana kategori ismi en fazla 50 karakter olmalıdır.");
        }
    }
}