using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.MenuLib;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (string.IsNullOrWhiteSpace(GameSession.Username))
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to Tic Tac Toe ===");
                Console.Write("Please enter your username: ");
                GameSession.Username = Console.ReadLine();
            }

            Menu currentMenu = new MainMenu();
            Menu[] menuHistory = new Menu[20];
            int historyIndex = 0;
            menuHistory[historyIndex] = currentMenu;

            while (currentMenu != null)
            {
                currentMenu.Display();
                Console.Write("\nSelect option: ");
                string input = Console.ReadLine()?.Trim();

                NavigationResult result = currentMenu.ExecuteOption(input);

                if (result.Type == NavigationResultType.Exit)
                {
                    break;
                }
                else if (result.Type == NavigationResultType.Back)
                {
                    if (historyIndex > 0)
                    {
                        historyIndex--;
                        currentMenu = menuHistory[historyIndex];
                    }
                }
                else if (result.Type == NavigationResultType.GoTo && result.Menu != null)
                {
                    historyIndex++;
                    menuHistory[historyIndex] = result.Menu;
                    currentMenu = result.Menu;
                }
            }

            Console.Clear();
            Console.WriteLine("Thank you for playing!");
        }
    }
}
