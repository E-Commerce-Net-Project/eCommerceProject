using DtoLayer.Dtos.MainCategoryDtos;
using DtoLayer.Dtos.ServiceDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.Service
{
    public class CreateServiceDtoValidator : AbstractValidator<CreateServiceDto>
    {
        public CreateServiceDtoValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithName("Başlık").WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Description).NotEmpty().WithName("Açıklama").WithMessage(ValidationMessages.NotEmpty);
        }
    }
}
