using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Xna.Framework.Input;

namespace Dodgy.Application.Sprite
{
    public interface IPlayerFactory
    {
        IPlayer GetPlayerOne();
        IPlayer GetPlayerTwo();
    }

    public class PlayerFactory : IPlayerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PlayerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public IPlayer GetPlayerOne()
        {
            var player = _serviceProvider.GetService<IPlayer>();
            player.Input = new Input
            {
                Up = Keys.W,
                Down = Keys.S,
                Left = Keys.A,
                Right = Keys.D
            };
            player.InitialPosition(20, 270);

            return player;
        }

        public IPlayer GetPlayerTwo()
        {
            var player = _serviceProvider.GetService<IPlayer>();
            player.Input = new Input
            {
                Up = Keys.Up,
                Down = Keys.Down,
                Left = Keys.Left,
                Right = Keys.Right
            };

            player.InitialPosition(580, 270);

            return player;
        }
    }
}