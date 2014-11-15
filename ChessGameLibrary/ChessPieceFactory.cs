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
                    pieces.Add(new Pawn(new Position(i, 1), i+1, PieceType.Pawn, ChessColor.Black));
                }
                pieces.Add(new Rook(new Position(0, 0), 9, PieceType.Rook, ChessColor.Black));
                pieces.Add(new Knight(new Position(1, 0), 10, PieceType.Knight, ChessColor.Black));
                pieces.Add(new Bishop(new Position(2, 0), 11, PieceType.Bishop, ChessColor.Black));
                pieces.Add(new Queen(new Position(3, 0), 12, PieceType.Queen, ChessColor.Black));
                pieces.Add(new King(new Position(4, 0), 13, PieceType.King, ChessColor.Black));
                pieces.Add(new Bishop(new Position(5, 0), 14, PieceType.Bishop, ChessColor.Black));
                pieces.Add(new Knight(new Position(6, 0), 15, PieceType.Knight, ChessColor.Black));
                pieces.Add(new Rook(new Position(7, 0), 16, PieceType.Rook, ChessColor.Black));
                
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    pieces.Add(new Pawn(new Position(i, 6), i+1, PieceType.Pawn, ChessColor.White));
                }
                pieces.Add(new Rook(new Position(0, 7), 9, PieceType.Rook, ChessColor.White));
                pieces.Add(new Knight(new Position(1, 7), 10, PieceType.Knight, ChessColor.White));
                pieces.Add(new Bishop(new Position(2, 7), 11, PieceType.Bishop, ChessColor.White));
                pieces.Add(new Queen(new Position(3, 7), 12, PieceType.Queen, ChessColor.White));
                pieces.Add(new King(new Position(4, 7), 13, PieceType.King, ChessColor.White));
                pieces.Add(new Bishop(new Position(5, 7), 14, PieceType.Bishop, ChessColor.White));
                pieces.Add(new Knight(new Position(6, 7), 15, PieceType.Knight, ChessColor.White));
                pieces.Add(new Rook(new Position(7, 7), 16, PieceType.Rook, ChessColor.White));
            }
            return pieces;

           
        }
    }
}
