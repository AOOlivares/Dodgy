using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodgy.Application.Sprite
{
    public interface IPlayerFactory
    {
        Player GetPlayerOne(GraphicsDevice graphicsDevice);
        Player GetPlayerTwo(GraphicsDevice graphicsDevice);
    }

    public class PlayerFactory : IPlayerFactory
    {
        public Player GetPlayerOne(GraphicsDevice graphicsDevice) =>
                new Player(graphicsDevice, 100, 20)
                {
                    Input = new Input
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D
                    }
                };

        public Player GetPlayerTwo(GraphicsDevice graphicsDevice) =>
                new Player(graphicsDevice, 10, 20)
                {
                    Input = new Input
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                };
    }
}