using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class ChessPieceFactory
    {
        public IChessPiece CreateChessPiece()
        {
            return new Pawn(new Position(0, 1), 1,PieceType.Pawn); 
        }
    }
}
