using System;
using Dodgy.Application.Ioc;

namespace Dodgy.Application
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
                game.Run();
        }
    }
}
