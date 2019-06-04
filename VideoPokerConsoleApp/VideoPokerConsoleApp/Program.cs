using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoPokerConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set console size
            Console.SetWindowSize(110, 25);
            Console.SetBufferSize(110, 25);

            // Set console color
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            // Runs the game
            Template gamePlay = new Gameplay();
            gamePlay.TemplateMethod();
        }
    }
}
