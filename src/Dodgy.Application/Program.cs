using System;
using Dodgy.Application.Ioc;

namespace Dodgy.Application
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = ApplicationContainer.Instance;
            var game = (Game1)container.GetService(typeof(Game1));
            using (game)
                game.Run();
        }
    }
}
