using Ardalis.Result;
using Auth.Application.Features.Users.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.Commands
{
    public class LoginCommand : IRequest<Result<LoginResponse>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
