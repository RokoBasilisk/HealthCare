using Auth.Domain.Entities.ClientAggregate.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.Commands
{
    public class RegistUserCommandValidator : AbstractValidator<RegistUserCommand>
    {
        public RegistUserCommandValidator()
        {
            RuleFor(command => command.Email)
                .NotEmpty(); // Email Required

            RuleFor(command => command.Password)
                .NotEmpty(); // Password Required

            RuleFor(command => command.Name)
                .NotEmpty(); // User Fullname Required

            RuleFor(command => command.Gender)
                .NotNull() // Gender Required
                .InclusiveBetween(0, 1); // Gender must be Male or Female
        }
    }
}
