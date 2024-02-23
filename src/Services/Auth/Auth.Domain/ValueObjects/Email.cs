using Ardalis.Result;
using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Domain.ValueObjects
{
    public sealed record Email
    {
        public string Address { get; }

        private Email(string address) =>
            Address = address.Trim();

        private Email() { }

        public static Result<Email> Create(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress))
                return Result<Email>.Error("The Email Address must be provided");

            return !RegexPatterns.EmailIsValid.IsMatch(emailAddress)
                ? Result<Email>.Error("The email address is not valid")
                : Result<Email>.Success(new Email(emailAddress));
        }
    }
}
