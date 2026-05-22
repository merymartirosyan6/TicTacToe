using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.MenuLib;

namespace TicTacToe
{
    internal class MainMenu : Menu
    {
        public MainMenu() : base("Main Menu")
        {
            ConfigureOptionSize(4);
            AddOption("1", "Play");
            AddOption("2", "Settings");
            AddOption("3", "About");
            AddOption("4", "Quit");
        }
        protected override NavigationResult HandleOption(string option)
        {
            switch (option)
            {
                case "1":
                    return NavigationResult.GoTo(new GameplayModeMenu());
                case "2":
                    return NavigationResult.GoTo(new SettingsMenu());
                case "3":
                    return NavigationResult.GoTo(new AboutMenu());
                case "4":
                    return NavigationResult.Exit();
                default:
                    return NavigationResult.None();
            }
        }
    }
}
