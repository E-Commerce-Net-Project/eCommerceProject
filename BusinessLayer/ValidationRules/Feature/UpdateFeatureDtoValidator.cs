using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoLayer.Dtos.AboutDtos;
using DtoLayer.Dtos.FeatureDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.Feature
{
    public class UpdateFeatureDtoValidator : AbstractValidator <UpdateFeatureDto>
    {
        public UpdateFeatureDtoValidator() 
        {
            RuleFor(x => x.Title1).NotEmpty().WithMessage("Özellik bilgisi boş bırakılmamalıdır.");
        }
    }
}
