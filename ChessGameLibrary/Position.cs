using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public enum PieceType
    {
        Pawn = 1, Knight = 3, Rook = 5, Bishop = 4, King = 10, Queen = 9
    }
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y) 
        {
            X = x;
            Y = y;
        }
    }
}
