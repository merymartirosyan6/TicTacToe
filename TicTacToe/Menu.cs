using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Menu
    {
        private string username;
        public Menu()
        {
            username = "";
        }
        public void EnterUsername()
        {
            Console.Clear();

            Console.WriteLine("Enter your username:");

            username = Console.ReadLine();

            while (username == "")
            {
                Console.WriteLine("Username cannot be empty!");
                username = Console.ReadLine();
            }
        }
        public void ShowMainMenu()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("=== TIC TAC TOE ===");
                Console.WriteLine();
                Console.WriteLine("1. Play");
                Console.WriteLine("2. Settings");
                Console.WriteLine("3. About");
                Console.WriteLine("4. Quit");
                Console.WriteLine();
                Console.WriteLine("Choose option:");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    ShowPlayMenu();
                }
                else if (choice == "2")
                {
                    ShowSettings();
                }
                else if (choice == "3")
                {
                    ShowAbout();
                }
                else if (choice == "4")
                {
                    break;
                }
            }
        }
        private void ShowPlayMenu()
        {
            Console.Clear();

            Console.WriteLine("1. Player vs Player");
            Console.WriteLine("2. Player vs Computer");

            string choice = Console.ReadLine();

            Console.WriteLine("Choose symbol (X/O):");

            char symbol = Convert.ToChar(Console.ReadLine().ToUpper());

            char secondSymbol;

            if (symbol == 'X')
            {
                secondSymbol = 'O';
            }
            else
            {
                secondSymbol = 'X';
            }

            Player player1 = new Player(username, symbol);

            Player player2;

            // PVP
            if (choice == "1")
            {
                Console.WriteLine("Enter second player username:");

                string secondName = Console.ReadLine();
                while (secondName == "")
                {
                    Console.WriteLine("Username cannot be empty!");
                    secondName = Console.ReadLine();
                }

                player2 = new Player(secondName, secondSymbol);
            }

            // PVC
            else
            {
                player2 = new Player("Computer", secondSymbol);
            }

            Game game = new Game(player1, player2);

            game.Start();
        }
        private void ShowSettings()
        {
            Console.Clear();

            Console.WriteLine("Current username: " + username);

            Console.WriteLine("Enter new username:");

            username = Console.ReadLine();

            Console.WriteLine("Username changed!");

            Console.ReadKey();
        }
        private void ShowAbout()
        {
            Console.Clear();

            Console.WriteLine("Developer: Mery Martirosyan");
            Console.WriteLine("Course: TechGen");
            Console.WriteLine("Year: 2026");

            Console.WriteLine();
            Console.WriteLine("Press any key...");

            Console.ReadKey();
        }
    }
}
