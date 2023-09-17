using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoLayer.Dtos.AboutDtos;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BusinessLayer.ValidationRules.About
{
    public class UpdateAboutDtoValidator : AbstractValidator <UpdateAboutDto>
    {
        public UpdateAboutDtoValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithName("Açıklama").WithMessage(ValidationMessages.NotEmpty)
                .MinimumLength(ValidationMessages.MinimumLength).WithMessage(ValidationMessages.MinimumLengthMessage)
                .MaximumLength(ValidationMessages.MaximumLength).WithMessage(ValidationMessages.MaximumLengthMessage);
        }

    }
}
