using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class Pawn : IChessPiece
    {

        public List<Position> ValidMove;

        public bool StartPosition { get; set; }
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }

        public Pawn(Position chessPiecePosition, int pieceId, PieceType pieceType)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = true;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
        }



        public List<Position> GetValidMove()
        {
            ValidMove = new List<Position>();
            if (PieceId > 15)// PieceColor.White
            {
                if (StartPosition == true)
                {
                    ValidMove.Add(new Position(ChessPiecePosition.X-1, ChessPiecePosition.Y - 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X+1, ChessPiecePosition.Y - 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 2));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y-1));
                   
                }
                else if (StartPosition == false)
                {
                    ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y - 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y - 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 1));
                }
                
            }
            else// Black pieces
            {
                if (StartPosition == true)
                {
                    ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y + 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y + 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 2));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1)); 
                    
                }
                else if (StartPosition == false)
                {
                    ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y + 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y + 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
                }
                
            }

            return ValidMove;

        }
    }
}
