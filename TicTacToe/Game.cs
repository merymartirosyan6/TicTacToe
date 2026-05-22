using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        private Board board;
        private Random random;

        private Player player1;
        private Player player2;
        public Game()
        {
            board = new Board();
            random = new Random();
        }
        
        public void Start()
        {
            int selectedRow = 1;
            int selectedCol = 1;
            player1 = new Player(GameSession.Username, GameSession.PlayerSymbol);
            char p2Symbol = (player1.Symbol == 'X') ? '0' : 'X';
            player2 = new Player(GameSession.Player2Username, p2Symbol);
            board = new Board();
            Player currentPlayer = (player1.Symbol == 'X') ? player1 : player2;

            while (true)
            {
                board.Draw(selectedRow, selectedCol);
                Console.WriteLine($"Current Turn: {currentPlayer.Username} ({currentPlayer.Symbol})");
                Console.WriteLine("Use Arrow Keys (↑, ↓, ←, →) to navigate, Enter to place symbol.");
                if (GameSession.IsVsComputer && currentPlayer == player2)
                {
                    System.Threading.Thread.Sleep(700);
                    MakeComputerMove(player2.Symbol);

                    if (CheckGameStatus(currentPlayer)) break;

                    currentPlayer = player1;
                    continue;
                }
                ConsoleKeyInfo key = Console.ReadKey(true);

                // UP
                if (key.Key == ConsoleKey.W ||
                    key.Key == ConsoleKey.UpArrow)
                {
                    if (selectedRow > 0)
                    {
                        selectedRow--;
                    }
                }

                // DOWN
                else if (key.Key == ConsoleKey.S ||
                         key.Key == ConsoleKey.DownArrow)
                {
                    if (selectedRow < 2)
                    {
                        selectedRow++;
                    }
                }

                // LEFT
                else if (key.Key == ConsoleKey.A ||
                         key.Key == ConsoleKey.LeftArrow)
                {
                    if (selectedCol > 0)
                    {
                        selectedCol--;
                    }
                }

                // RIGHT
                else if (key.Key == ConsoleKey.D ||
                         key.Key == ConsoleKey.RightArrow)
                {
                    if (selectedCol < 2)
                    {
                        selectedCol++;
                    }
                }

                // ENTER -> PLACE MARK
                else if (key.Key == ConsoleKey.Enter)
                {
                    if (board.PlaceMark(selectedRow, selectedCol, currentPlayer.Symbol))
                    {
                        if (CheckGameStatus(currentPlayer)) break;
                        currentPlayer = (currentPlayer == player1) ? player2 : player1;
                    }
                }
            }
            Console.WriteLine("\nPress any key to return to Main Menu...");
            Console.ReadKey();
        }

        public void MakeComputerMove(char computerSymbol)
        {
            bool moved = false;
            while (!moved && !board.IsFull())
            {
                int r = random.Next(0, 3);
                int c = random.Next(0, 3);
                if (board.PlaceMark(r, c, computerSymbol))
                {
                    moved = true;
                }
            }
        }

        private bool CheckGameStatus(Player player)
        {
            if (board.CheckWinner(player.Symbol))
            {
                board.Draw(-1, -1);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{player.Username} ({player.Symbol}) WINS!");
                Console.ResetColor();
                return true;
            }
            if (board.IsFull())
            {
                board.Draw(-1, -1);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nIt's a Draw! No one wins.");
                Console.ResetColor();
                return true;
            }

            return false;
        }
    }
}
