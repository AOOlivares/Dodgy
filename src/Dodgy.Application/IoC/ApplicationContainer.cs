using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Dodgy.Application.Ioc.ServiceCollectionExtensions;

namespace Dodgy.Application.Ioc
{
    public class ApplicationContainer : IServiceProvider
    {
        public static readonly ApplicationContainer Instance = new ApplicationContainer();
        private readonly IConfigurationRoot _configurationRoot;
        private readonly IServiceCollection _serviceCollection;
        private IServiceProvider _serviceProvider;

        public ApplicationContainer(IConfigurationRoot config = null)
        {
            _configurationRoot = config ?? BuildConfigurationRoot();
            _serviceCollection = new ServiceCollection();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection
                .AddConfiguration(_configurationRoot);
        }

        public object GetService(Type serviceType)
        {
            if (_serviceProvider != null)
            {
                return _serviceProvider.GetService(serviceType);
            }

            ConfigureServices(_serviceCollection);
            _serviceProvider = _serviceCollection.BuildServiceProvider();
            return _serviceProvider.GetService(serviceType);
        }

        private IConfigurationRoot BuildConfigurationRoot() =>
            new ConfigurationBuilder()
                .Build();
    }
}