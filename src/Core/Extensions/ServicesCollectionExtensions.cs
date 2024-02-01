using Core.AppSettings;
using Core.SharedKernel;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection ConfigureAppSettings(this IServiceCollection services) =>
            services.AddOptionsWithValidation<ConnectionOptions>();

        private static IServiceCollection AddOptionsWithValidation<TOption>(this IServiceCollection services)
            where TOption : class, IAppOptions
        {
            return services
                .AddOptions<TOption>()
                .BindConfiguration(TOption.ConfigSectionPath, binderOptions => binderOptions.BindNonPublicProperties = true)
                .ValidateDataAnnotations()
                .ValidateOnStart()
                .Services;
        }
    }
}
