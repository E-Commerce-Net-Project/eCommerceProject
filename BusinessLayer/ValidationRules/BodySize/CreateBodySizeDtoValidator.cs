using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DtoLayer.Dtos.BodySizeDtos;
using FluentValidation;

namespace BusinessLayer.ValidationRules.BodySize
{
    public class CreateBodySizeDtoValidator : AbstractValidator <CreateBodySizeDto>
    {
        public CreateBodySizeDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Beden Bilgisi boş bırakılmamalıdır.");
            
        }
    }
}
