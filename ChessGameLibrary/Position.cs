using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public enum PieceType
    {
        Pawn, Knight, Rook, Bishop, King, Queen
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
