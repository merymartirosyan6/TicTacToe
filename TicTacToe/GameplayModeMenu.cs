using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToe.MenuLib;

namespace TicTacToe
{
    internal class GameplayModeMenu : Menu
    {
        public GameplayModeMenu() : base("GamePlay Mode Selection")
        {
            ConfigureOptionSize(2);
            AddOption("1", "Player vs Player");
            AddOption("2", "Player vs Computer");
        }
        protected override NavigationResult HandleOption(string option)
        {
            if (option == "1")
            {
                GameSession.IsVsComputer = false;
                Console.Clear();
                Console.Write("Enter Second Player's Username: ");
                string p2Name = Console.ReadLine();
                GameSession.Player2Username = !string.IsNullOrWhiteSpace(p2Name) ? p2Name : "Player 2";
            }
            else if (option == "2")
            {
                GameSession.IsVsComputer = true;
                GameSession.Player2Username = "Computer";
            }
            else
            {
                return NavigationResult.None();
            }
            Console.Clear();
            Console.Write($"{GameSession.Username}, choose your symbol (X / 0): ");
            char symbol = char.ToUpper(Console.ReadKey().KeyChar);
            GameSession.PlayerSymbol = (symbol == 'X' || symbol == '0') ? symbol : 'X';
            
            Game game = new Game();
            game.Start();

            return NavigationResult.Back();
        }
    }
}
