using System;

namespace GameDev_EindWerk1
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            //test 123
            using (var game = new Game1())
                game.Run();
        }
    }
}
