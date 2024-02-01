using Ardalis.Result;
using Auth.Application.Features.Roles.Commands;
using Auth.Application.Features.Roles.Responses;
using Auth.Application.Wrappers.Abstracts;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.Factories;
using Core.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Handlers
{
    public class CreateRoleCommandHandler(IRoleWriteRepository roleWriteRepository, IUnitOfWork unitOfWork) : IRequestHandler<CreateRoleCommand, Result<CreateRoleResponse>>
    {
        public async Task<Result<CreateRoleResponse>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {

            var role = RoleFactory.Create(request.RoleName, request.RoleDescription);

            roleWriteRepository.AddAsync(role);

            await unitOfWork.SaveChangesAsync();

            return Result<CreateRoleResponse>.Success(new CreateRoleResponse(role.Id), $"Create Role {role.RoleName} Successfully");
        }
    }
}
