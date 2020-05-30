using Dodgy.Application.Window;
using Microsoft.Xna.Framework;

namespace Dodgy.Application.Sprite
{
    public interface IMovement
    {
        void InitialPosition(float x, float y, int width, int height);
        void Up(float elapsedSeconds);
        void Down(float elapsedSeconds);
        void Left(float elapsedSeconds);
        void Right(float elapsedSeconds);

        Vector2 Position { get; }
    }

    public class Movement : IMovement
    {
        private Vector2 _position;

        private int _objectWidth { get; set; }
        private int _objectHeight { get; set; }

        public Vector2 Position => _position;

        private float _speed = 500f;
        private readonly IWindow _window;

        public Movement(IWindow window)
        {
            _window = window;
        }

        public void InitialPosition(float x, float y, int width, int height)
        {
            _position = new Vector2(x, y);
            _objectWidth = width;
            _objectHeight = height;
        }

        public void Up(float elapsedSeconds)
        {
            _position.Y -= _speed * (float)elapsedSeconds;
            WithinLimits();
        }

        public void Down(float elapsedSeconds)
        {
            _position.Y += _speed * (float)elapsedSeconds;
            WithinLimits();
        }

        public void Left(float elapsedSeconds)
        {
            _position.X -= _speed * (float)elapsedSeconds;
            WithinLimits();
        }

        public void Right(float elapsedSeconds)
        {
            _position.X += _speed * (float)elapsedSeconds;
            WithinLimits();
        }

        private void WithinLimits()
        {
            if (_position.X > _window.Width - _objectWidth * 2)
            {
                _position.X = _window.Width - _objectWidth * 2;
            }
            else if (_position.X < _objectWidth / 2)
            {
                _position.X = _objectWidth;
            }

            if (_position.Y > _window.Height - (_objectHeight + 20))
            {
                _position.Y = _window.Height - (_objectHeight + 20);
            }
            else if (_position.Y <= 20)
            {
                _position.Y = 20;
            }
        }
    }
}