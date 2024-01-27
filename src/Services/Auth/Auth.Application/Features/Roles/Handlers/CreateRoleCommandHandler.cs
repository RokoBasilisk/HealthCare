using Auth.Application.Features.Roles.Commands;
using Auth.Application.Wrappers.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Handlers
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, IResponse>
    {
        public async Task<IResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return null;
        }
    }
}
