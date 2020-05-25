using Dodgy.Application.Sprite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Dodgy.Application.Ioc.ServiceCollectionExtensions
{
    public static class Monogame
    {
        public static IServiceCollection AddMonogame(this IServiceCollection services)
        {
            services
                .AddSingleton(serviceProvider =>
                {
                    var factory = serviceProvider.GetService<IPlayerFactory>();
                    return new Game1(factory);
                })
                .AddSingleton<IGraphicsDeviceService>(serviceProvider =>
                {
                    var game1 = serviceProvider.GetService<Game1>();
                    return game1.Graphics;
                })
                .AddSingleton<IGraphicsDeviceManager>(serviceProvider =>
                {
                    var game1 = serviceProvider.GetService<Game1>();
                    return game1.Graphics;
                });

            return services;
        }
    }
}