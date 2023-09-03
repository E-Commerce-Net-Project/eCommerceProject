using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.SponsorDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Sponsor
{
    public class UpdateSponsorDtoValidator : AbstractValidator<UpdateSponsorDto>
    {
        public UpdateSponsorDtoValidator()
        {
            RuleFor(x => x.Image).NotEmpty().WithMessage("Resim alanı boş geçilemez.");
        }
    }
}
