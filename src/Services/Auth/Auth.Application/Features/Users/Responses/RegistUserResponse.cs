using Auth.Application.Wrappers.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.Responses
{
    public class RegistUserResponse(Guid id) : IResponse
    {
        public Guid Id { get; } = id;
    }
}
