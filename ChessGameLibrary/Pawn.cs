using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class Pawn : IChessPiece
    {
        public Position StartPosition { get; set; }
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }

        public Pawn(Position chessPiecePosition, int pieceId, PieceType pieceType)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = chessPiecePosition;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
        }

        public List<Position> GetValidMove()
        {
            return null;
        }
    }
}
