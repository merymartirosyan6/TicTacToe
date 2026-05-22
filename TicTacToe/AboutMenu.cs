using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.MenuLib;

namespace TicTacToe
{
    internal class AboutMenu : Menu
    {
        public AboutMenu():base("About Developer")
        {
            ConfigureOptionSize(0);
        }
        protected override void InternalDisplay()
        {
            Console.WriteLine("\n=================================");
            Console.WriteLine("Developer: Mery Martirosyan");
            Console.WriteLine("Course: TechGen / ACA C#");
            Console.WriteLine("Project: Console Tic Tac Toe");
            Console.WriteLine("Year: 2026");
            Console.WriteLine("=================================");
        }
        protected override NavigationResult HandleOption(string option)
        {
            return NavigationResult.None();
        }
    }
}
