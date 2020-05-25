using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dodgy.Application.Ioc.ServiceCollectionExtensions
{
    public static class Configuration
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            services
                .AddSingleton(configurationRoot);

            return services;
        }
    }
}