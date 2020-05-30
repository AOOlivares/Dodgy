using System;
using Microsoft.Extensions.DependencyInjection;
using Dodgy.Application.Ioc;

namespace Dodgy.Application
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = ApplicationContainer.Instance;
            var game = container.GetService<Game1>();
            using (game)
                game.Run();
        }
    }
}
