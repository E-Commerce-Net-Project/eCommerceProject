using DtoLayer.Dtos.GenreCategoryDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.GenreCategory
{
    public class CreateGenreCategoryDtoValidator : AbstractValidator<CreateGenreCategoryDto>
    {
        public CreateGenreCategoryDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori türü isim alanı boş bırakılmamalıdır.").MinimumLength(5).WithMessage("Kategori türü ismi en az 5 karakter olmalıdır.").MaximumLength(50).WithMessage("Kategori türü ismi en fazla 50 karakter olmalıdır.");
        }
    }
}