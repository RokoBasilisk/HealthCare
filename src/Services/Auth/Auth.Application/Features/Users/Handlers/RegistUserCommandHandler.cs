using Ardalis.Result;
using Ardalis.Result.FluentValidation;
using Auth.Application.Features.Roles.Responses;
using Auth.Application.Features.Users.Commands;
using Auth.Application.Features.Users.Responses;
using Auth.Application.Helpers;
using Auth.Domain.Entities.ClientAggregate;
using Auth.Domain.Entities.ClientAggregate.Enums;
using Auth.Domain.Entities.EntityAggregate;
using Auth.Domain.Entities.RoleAggregate;
using Auth.Domain.Factories;
using Auth.Domain.ValueObjects;
using Core.SharedKernel;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Application.Features.Users.Handlers
{
    internal class RegistUserCommandHandler(
        IClientWriteRepository clientWriteRepository,
        IValidator<RegistUserCommand> validator,
        IRoleWriteRepository roleWriteRepository,
        IUnitOfWork unitOfWork) : IRequestHandler<RegistUserCommand, Result<RegistUserResponse>>
    {
        private readonly IClientWriteRepository _clientWriteRepository = clientWriteRepository;
        private readonly IRoleWriteRepository _roleWriteRepository = roleWriteRepository;
        private readonly IValidator<RegistUserCommand> _validator = validator;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly string CLIENT_ROLE = "Client";

        public async Task<Result<RegistUserResponse>> Handle(RegistUserCommand request, CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Result<RegistUserResponse>.Invalid(validationResult.AsErrors());
            }

            var emailResult = Email.Create(request.Email);
            if (!emailResult.IsSuccess)
                return Result<RegistUserResponse>.Error(emailResult.Errors.ToArray());

            if (await _clientWriteRepository.ExistsAsync(emailResult.Value))
            {
                return Result<RegistUserResponse>.Error("Email is already exist, please change another email address");
            }

            var (passwordHashed, passwordSalt) = PasswordHelper.CreateHash(request.Password);

            var client = ClientFactory.Create(emailResult.Value);

            var gender = EGender.GetById(request.Gender);

            var clientInformation = ClientInformationFactory.Create(request.Name, gender, request.IsLocked, request.ExpiredDate, client);
            var clientPassword = ClientPasswordFactory.Create(passwordHashed, passwordSalt, client);
            var basicRole = await _roleWriteRepository.GetRoleByNameAsync(CLIENT_ROLE);

            client.ClientInformation = clientInformation;
            client.ClientInformationId = clientInformation.Id;
            client.ClientPassword = clientPassword;
            client.ClientPasswordId = clientPassword.Id;

            client.clientRoles = [new ClientRole(client.Id, basicRole.Id)];

            _clientWriteRepository.AddAsync(client);

            await _unitOfWork.SaveChangesAsync();

            return Result<RegistUserResponse>.Success(new RegistUserResponse(client.Id), $"Regist User account with {client.Email} Successfully");
        }
    }
}
