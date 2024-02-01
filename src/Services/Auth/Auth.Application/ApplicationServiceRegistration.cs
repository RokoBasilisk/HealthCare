using Auth.Application.Behaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Auth.Application
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationServiceRegistration
    {
        private static readonly Assembly ThisAssembly = Assembly.GetExecutingAssembly();
        public static IServiceCollection AddCommandHandler(this IServiceCollection services) =>
            services
                .AddMediatR(cfg => cfg
                    .AddBehavior(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                    .RegisterServicesFromAssembly(ThisAssembly))
                .AddValidatorsFromAssembly(ThisAssembly);
    }
}