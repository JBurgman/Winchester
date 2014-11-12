using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class ChessPieceFactory
    {
        // Fields
        readonly List<IChessPiece> pieces;
        
        public ChessPieceFactory(List<IChessPiece> pieces)
        {
            this.pieces = pieces;
        }
        public List<IChessPiece> CreateChessPiece(ChessColor playerId)
        {
            if (playerId==ChessColor.White)
            {

                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(new Position(i, 1), i + 1, PieceType.Pawn, ChessColor.White));
                }
                
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(new Position(i, 6), i + 9, PieceType.Pawn, ChessColor.Black));
                }

            }
            return pieces;

           
        }
    }
}
