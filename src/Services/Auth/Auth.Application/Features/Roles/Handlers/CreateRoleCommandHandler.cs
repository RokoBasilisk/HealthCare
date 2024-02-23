using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Auth.Application.Features.Roles.Commands;
using Auth.Application.Features.Roles.Responses;
using Auth.Application.Wrappers.Abstracts;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.Factories;
using Core.SharedKernel;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Handlers
{
    internal class CreateRoleCommandHandler(IRoleWriteRepository roleWriteRepository, IUnitOfWork unitOfWork, IValidator<CreateRoleCommand> _validator) : IRequestHandler<CreateRoleCommand, Result<CreateRoleResponse>>
    {
        public async Task<Result<CreateRoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {

            // Validate command attribute
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result<CreateRoleResponse>.Invalid(validationResult.AsErrors());
            }

            var role = RoleFactory.Create(request.RoleName, request.RoleDescription);

            roleWriteRepository.Add(role);

            await unitOfWork.SaveChangesAsync();

            return Result<CreateRoleResponse>.Success(new CreateRoleResponse(role.Id), $"Create Role {role.RoleName} Successfully");
        }
    }
}
