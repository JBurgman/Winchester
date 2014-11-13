using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    //public enum PieceType
    //{ 
    //    Pawn = 1,
    //    Bishop = 3,
    //    Knight = 3,
    //    Rook = 5,
    //    Queen = 9,
    //    King = 10,
    //}


    abstract class ChessPiece
    {
        public Position ChessPiecePosition = new Position();
        public int PieceID;

        //Type - piecetype

        //public PieceType type; ?

    }
}
