﻿using DtoLayer.Dtos.AppRoleDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AppRole
{
    public class CreateAppRoleDtoValidator : AbstractValidator<CreateAppRoleDto>
    {
        public CreateAppRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Rol Adı alanı boş bırakılmamalıdır.").MinimumLength(5).WithMessage("Rol adı en az 5 karakter olmalıdır.").MaximumLength(50).WithMessage("Rol adı en fazla 50 karakter olmalıdır.");
        }
    }
}
