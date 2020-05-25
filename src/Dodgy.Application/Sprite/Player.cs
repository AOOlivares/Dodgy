using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Dodgy.Application.Sprite
{
    public interface IPlayer
    {
        void Update(float elapsedSeconds, int preferredBackBufferWidth, int preferredBackBufferHeight);
        void Draw(SpriteBatch spriteBatch);
    }

    public class Player : IPlayer
    {
        public Input Input;
        private Texture2D _texture;
        private readonly IMovement _movement;
        private Vector2 Position;
        private float _speed = 500f;
        private int _width = 10;
        private int _height = 60;

        public Player(GraphicsDevice device, float x, float y)
        {
            _texture = new Texture2D(device, _width, _height);
            _texture.SetData(GetColorData(Color.Chocolate));
            Position = new Vector2(x, y);
        }

        public void Update(float elapsedSeconds, int preferredBackBufferWidth, int preferredBackBufferHeight)
        {
            Move(_speed, elapsedSeconds, preferredBackBufferWidth, preferredBackBufferHeight);
        }

        public void Move(float speed, float elapsedSeconds, int preferredBackBufferWidth, int preferredBackBufferHeight)
        {
            var state = Keyboard.GetState();

            if (state.IsKeyDown(Input.Up))
            {
                Position.Y -= speed * (float)elapsedSeconds;
            }
            if (state.IsKeyDown(Input.Down))
            {
                Position.Y += speed * (float)elapsedSeconds;
            }
            if (state.IsKeyDown(Input.Left))
            {
                Position.X -= speed * (float)elapsedSeconds;
            }
            if (state.IsKeyDown(Input.Right))
            {
                Position.X += speed * (float)elapsedSeconds;
            }

            if (Position.X > preferredBackBufferWidth - _texture.Width * 2)
            {
                Position.X = preferredBackBufferWidth - _texture.Width * 2;
            }
            else if (Position.X < _texture.Width / 2)
            {
                Position.X = _texture.Width;
            }

            if (Position.Y > preferredBackBufferHeight - _texture.Height)
            {
                Position.Y = preferredBackBufferHeight - _texture.Height;
            }
            else if (Position.Y < _texture.Height / 4)
            {
                Position.Y = _texture.Height / 4;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
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