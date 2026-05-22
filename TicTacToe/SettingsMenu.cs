using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.MenuLib;

namespace TicTacToe
{
    internal class SettingsMenu : Menu
    {
        public SettingsMenu() : base("Settings")
        {
            ConfigureOptionSize(1);
            AddOption("1", "Change Username");
        }
        protected override void InternalDisplay()
        {
            Console.WriteLine($"\nCurrent Username: {GameSession.Username}");
        }
        protected override NavigationResult HandleOption(string option)
        {
            if (option == "1")
            {
                Console.Write("\nEnter new username: ");
                string newName = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(newName))
                {
                    GameSession.Username = newName;
                }
            }
            return NavigationResult.None();
        }
    }
}
