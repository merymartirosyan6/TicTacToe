using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Game
    {
        private Board board;

        private Player player1;
        private Player player2;
        private Player currentPlayer;

        private int selectedRow = 0;
        private int selectedCol = 0;

        public Game(Player p1, Player p2)
        {
            board = new Board();

            player1 = p1;
            player2 = p2;

            if (player1.Symbol == 'X')
            {
                currentPlayer = player1;
            }
            else
            {
                currentPlayer = player2;
            }
        }
        private void SwitchPlayer()
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else
            {
                currentPlayer = player1;
            }
        }
        public void Start()
        {
            while (true)
            {
                board.Draw(selectedRow, selectedCol);

                Console.WriteLine();
                Console.WriteLine(currentPlayer.Username + "'s turn");
                Console.WriteLine("Use WASD or Arrow Keys");
                Console.WriteLine("Press Enter to place mark");

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
                    bool success = board.PlaceMark(selectedRow, selectedCol, currentPlayer.Symbol);

                    // Occupied cell
                    if (!success)
                    {
                        continue;
                    }

                    // Winner
                    if (board.CheckWinner(currentPlayer.Symbol))
                    {
                        board.Draw(selectedRow, selectedCol);

                        Console.WriteLine();
                        Console.WriteLine(currentPlayer.Username + " wins!");

                        break;
                    }

                    // Draw
                    if (board.IsFull())
                    {
                        board.Draw(selectedRow, selectedCol);

                        Console.WriteLine();
                        Console.WriteLine("Draw!");

                        break;
                    }

                    // Next turn
                    SwitchPlayer();
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
