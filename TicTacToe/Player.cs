using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Player
    {
        public string Username;
        public char Symbol;

        public Player(string username, char symbol)
        {
            Username = username;
            Symbol = symbol;
        }
    }
}
