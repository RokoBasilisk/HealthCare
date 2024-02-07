using Ardalis.Result;
using Auth.Application.Features.Roles.Responses;
using Auth.Application.Wrappers.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Commands
{
    public record CreateRoleCommand : IRequest<Result<CreateRoleResponse>>
    {
        public string RoleName { get; set; }

        public string RoleDescription { get; set; }
    }
}
