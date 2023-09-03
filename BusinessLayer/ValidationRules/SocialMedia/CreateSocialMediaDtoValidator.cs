using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.SocialMediaDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.SocialMedia
{
    public class CreateSocialMediaDtoValidator : AbstractValidator<CreateSocialMediaDto>
    {
        public CreateSocialMediaDtoValidator()
        {
            RuleFor(x => x.Icon).NotEmpty().WithMessage("Icon alanı boş geçilemez.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez.");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Url alanı boş geçilemez.");
        }
    }
}
