using Ardalis.Result;
using Auth.Application.Features.Users.Commands;
using Auth.Application.Features.Users.Responses;
using Auth.Domain.Entities.ClientAggregate;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.Handlers
{
    internal class LoginCommandHandler : IRequestHandler<LoginCommand, Result<LoginResponse>>
    {
        private readonly IValidator<LoginCommand> _validator;
        private readonly IClientWriteRepository<LoginCommand> _clientWriteRepository;


        public Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result<RegistUserResponse>.Invalid(validationResult.AsErrors());
            }

        }
    }
}
