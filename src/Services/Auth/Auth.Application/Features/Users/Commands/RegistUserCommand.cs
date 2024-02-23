using Ardalis.Result;
using Auth.Application.Features.Users.Responses;
using Auth.Domain.Entities.ClientAggregate.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.Commands
{
    public record RegistUserCommand : IRequest<Result<RegistUserResponse>>
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public int Gender { get; set; }

        public DateTime ExpiredDate { get; } = DateTime.UtcNow.AddMonths(_expireDateMonths);

        public bool IsLocked { get; } = false;

        private static readonly int _expireDateMonths = 3;
    }
}
