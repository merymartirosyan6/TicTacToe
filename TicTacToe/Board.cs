using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Board
    {
        private char[,] cells;

        public Board()
        {
            cells = new char[3, 3];

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    cells[row, col] = ' ';
                }
            }
        }
        public void Draw(int selectedRow, int selectedCol)
        {
            Console.Clear();

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (row == selectedRow && col == selectedCol)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }

                    Console.Write(" " + cells[row, col] + " ");

                    Console.ResetColor();

                    if (col < 2)
                    {
                        Console.Write("|");
                    }
                }

                Console.WriteLine();

                if (row < 2)
                {
                    Console.WriteLine("---+---+---");
                }
            }
        }
        public bool PlaceMark(int row, int col, char symbol)
        {
            if (cells[row, col] == ' ')
            {
                cells[row, col] = symbol;
                return true;
            }

            return false;
        }
        public bool CheckWinner(char symbol)
        {
            // Rows
            for (int row = 0; row < 3; row++)
            {
                if (cells[row, 0] == symbol &&
                    cells[row, 1] == symbol &&
                    cells[row, 2] == symbol)
                {
                    return true;
                }
            }

            // Columns
            for (int col = 0; col < 3; col++)
            {
                if (cells[0, col] == symbol &&
                    cells[1, col] == symbol &&
                    cells[2, col] == symbol)
                {
                    return true;
                }
            }

            // Main diagonal
            if (cells[0, 0] == symbol &&
                cells[1, 1] == symbol &&
                cells[2, 2] == symbol)
            {
                return true;
            }

            // Other diagonal
            if (cells[0, 2] == symbol &&
                cells[1, 1] == symbol &&
                cells[2, 0] == symbol)
            {
                return true;
            }

            return false;
        }
        public bool IsFull()
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (cells[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
