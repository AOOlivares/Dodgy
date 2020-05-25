using Dodgy.Application.Sprite;
using Microsoft.Extensions.DependencyInjection;

namespace Dodgy.Application.Ioc.ServiceCollectionExtensions
{
    public static class Sprite
    {
        public static IServiceCollection AddSprite(this IServiceCollection services)
        {
            services
                .AddTransient<IPlayer, Player>()
                .AddTransient<IPlayerFactory, PlayerFactory>();

            return services;
        }
    }
}