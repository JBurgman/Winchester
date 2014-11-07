using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Rook:IChessPiece
    {

        public List<Position> ValidMove;

        public bool StartPosition { get; set; }
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }

        public Rook(Position chessPiecePosition, int pieceId, PieceType pieceType)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = true;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
        }



        public List<Position> GetValidMove()
        {
            ValidMove = new List<Position>();
            {
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 2, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 3, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 4, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 5, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 6, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X + 7, ChessPiecePosition.Y));

                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 2));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 3));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 4));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 5));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 6));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 7));

                ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X - 2, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X - 3, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X - 4, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X - 5, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X - 6, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X - 7, ChessPiecePosition.Y));

                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 1));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 2));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 3));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 4));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 5));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 6));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 7));
            }
            return ValidMove;
        }
    }
}
