using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Knight:IChessPiece
    {
        public List<Position> ValidMove;

        public bool StartPosition { get; set; }
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }

        public Knight(Position chessPiecePosition, int pieceId, PieceType pieceType)
        {
            ValidMove = new List<Position>();
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = true;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
        }
        public List<Position> GetValidMove()
        {

            ValidMove = new List<Position>();
            {
                ValidMove.Add(new Position(ChessPiecePosition.X+1, ChessPiecePosition.Y-2));
                ValidMove.Add(new Position(ChessPiecePosition.X + 2, ChessPiecePosition.Y-1));
                ValidMove.Add(new Position(ChessPiecePosition.X + 2, ChessPiecePosition.Y+1));
                ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y+2));
                ValidMove.Add(new Position(ChessPiecePosition.X -1, ChessPiecePosition.Y+2));
                ValidMove.Add(new Position(ChessPiecePosition.X -2, ChessPiecePosition.Y+1));
                ValidMove.Add(new Position(ChessPiecePosition.X -2, ChessPiecePosition.Y-1));
                ValidMove.Add(new Position(ChessPiecePosition.X -1, ChessPiecePosition.Y-2));
            }
            return ValidMove;
        }
    }
}
