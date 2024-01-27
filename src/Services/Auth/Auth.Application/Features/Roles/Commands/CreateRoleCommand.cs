using Auth.Application.Wrappers.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Commands
{
    public record CreateRoleCommand : IRequest<IResponse>
    {
    }
}
