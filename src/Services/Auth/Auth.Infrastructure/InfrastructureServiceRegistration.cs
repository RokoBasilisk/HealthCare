using Auth.Domain.Entities.RoleAggregate;
using Auth.Infrastructure.Persistence;
using Auth.Infrastructure.Repositories;
using Auth.Infrastructure.Repositories.Common;
using Auth.Infrastructure.Services;
using Core.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure
{
    public static class InfrastuctureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
            services
            .AddScoped<IEventStoreRepository, EventStoreRepository>()
            .AddScoped<IRoleWriteRepository, RoleWriteRepository>()
            .AddScoped<WriteDbContext>()
            .AddScoped<EventStoreDbContext>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }
}