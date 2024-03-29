﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Commands
{
    public class CreateRoleCommandValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommandValidator()
        {
            RuleFor(command => command.RoleName)
                .NotEmpty()
                .MaximumLength(10)
                .NotEqual("123456789011");

            RuleFor(command => command.RoleDescription)
                .NotEmpty()
                .MaximumLength(255);
        }
    }
}
