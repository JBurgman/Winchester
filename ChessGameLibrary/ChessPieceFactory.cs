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
            if (playerId==ChessColor.Black)
            {

                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(new Position(i, 1), i + 1, PieceType.Pawn));
                }
                pieces.Add(new Rook(new Position(0, 0), 9, PieceType.Rook));
                pieces.Add(new Knight(new Position(1, 0), 10, PieceType.Knight));
                pieces.Add(new Bishop(new Position(2,0),11,PieceType.Bishop));
                pieces.Add(new Queen(new Position(3, 0), 12, PieceType.Queen));
                pieces.Add(new King(new Position(4,0), 13, PieceType.King));
                pieces.Add(new Bishop(new Position(5,0),14,PieceType.Bishop));
                pieces.Add(new Knight(new Position(6, 0), 15, PieceType.Knight));
                pieces.Add(new Rook(new Position(7, 0), 16, PieceType.Rook));

                
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(new Position(i, 6), i + 17, PieceType.Pawn));
                }
                pieces.Add(new Rook(new Position(0, 7), 25, PieceType.Rook));
                pieces.Add(new Knight(new Position(1, 7), 26, PieceType.Knight));
                pieces.Add(new Bishop(new Position(2, 7), 27, PieceType.Bishop));
                pieces.Add(new Queen(new Position(3, 7), 28, PieceType.Queen));
                pieces.Add(new King(new Position(4, 7), 29, PieceType.King));
                pieces.Add(new Bishop(new Position(5, 7), 30, PieceType.Bishop));
                pieces.Add(new Knight(new Position(6, 7), 31, PieceType.Knight));
                pieces.Add(new Rook(new Position(7, 7), 32, PieceType.Rook));
            }
            return pieces;

           
        }
    }
}
