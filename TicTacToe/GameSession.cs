using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public static class GameSession
    {
        public static string Username { get; set; } = "";
        public static string Player2Username { get; set; } = "Player 2";
        public static bool IsVsComputer { get; set; } = false;
        public static char PlayerSymbol { get; set; } = 'X';
    }
}
