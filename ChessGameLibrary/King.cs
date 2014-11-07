using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class King : IChessPiece
    {

        public List<Position> ValidMove;

        public bool StartPosition { get; set; }
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }

        public King(Position chessPiecePosition, int pieceId, PieceType pieceType)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = true;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
        }



        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)
        {
            ValidMove = new List<Position>();
            {
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y));

                ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
                ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y));
                ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 1));

                ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y + 1));
                ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y - 1));
                ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y - 1));
                ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y + 1));
            }
            return ValidMove;

        }
    }
}