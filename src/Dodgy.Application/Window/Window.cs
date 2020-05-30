namespace Dodgy.Application.Window
{
    public interface IWindow
    {
        float Width { get; }
        float Height { get; }
    }

    public class Window : IWindow
    {
        private readonly float _width;
        private readonly float _height;

        public Window(float width, float height)
        {
            _width = width;
            _height = height;
        }

        public float Width => _width;

        public float Height => _height;
    }
}