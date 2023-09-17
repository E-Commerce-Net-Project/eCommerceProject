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
    public class CreateSponsorDtoValidator : AbstractValidator<CreateSponsorDto>
    {
        public CreateSponsorDtoValidator()
        {
            RuleFor(x => x.Image).NotEmpty().WithName("Resim").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
