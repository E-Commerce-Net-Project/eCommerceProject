using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoLayer.Dtos.FeatureDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.Feature
{
    public class CreateFeatureDtoValidator : AbstractValidator<CreateFeatureDto>
    {
        public CreateFeatureDtoValidator() 
        {
            RuleFor(x => x.Title1).NotEmpty().WithName("Özellik bilgisi").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
