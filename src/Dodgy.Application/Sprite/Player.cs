using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodgy.Application.Sprite
{
    public interface IPlayer
    {
        void Update(float elapsedSeconds);
        void Draw(SpriteBatch spriteBatch);

        Input Input { get; set; }
        void InitialPosition(float x, float y);
    }

    public class Player : IPlayer
    {
        public Input Input { get; set; }
        private Texture2D _texture;
        private readonly IMovement _movement;
        private int _width = 10;
        private int _height = 60;

        public Player(IGraphicsDeviceService deviceService, IMovement movement)
        {
            _texture = new Texture2D(deviceService.GraphicsDevice, _width, _height);
            _texture.SetData(GetColorData(Color.Chocolate));
            _movement = movement;
        }

        public void InitialPosition(float x, float y)
        {
            _movement.InitialPosition(x, y, _texture.Width, _texture.Height);
        }

        public void Update(float elapsedSeconds)
        {
            Move(elapsedSeconds);
        }

        public void Move(float elapsedSeconds)
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Input.Up))
            {
                _movement.Up(elapsedSeconds);
            }
            if (state.IsKeyDown(Input.Down))
            {
                _movement.Down(elapsedSeconds);
            }
            if (state.IsKeyDown(Input.Left))
            {
                _movement.Left(elapsedSeconds);
            }
            if (state.IsKeyDown(Input.Right))
            {
                _movement.Right(elapsedSeconds);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _movement.Position, Color.White);
        }

        private Color[] GetColorData(Color color)
        {
            Color[] data = new Color[_width * _height];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = color;
            }

            return data;
        }
    }
}