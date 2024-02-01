using Auth.Application.Wrappers.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Roles.Responses
{
    public class CreateRoleResponse(Guid id) : IResponse
    {
        public Guid Id { get; } = id;
    }
}
