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
        public ChessColor PieceColor { get; set; }

        public Pawn(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = true;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
            this.PieceColor = pieceColor;
        }



        public List<Position> GetValidMove()
        {
            ValidMove = new List<Position>();
            if (PieceColor==ChessColor.White)// PieceColor.White
            {
                if (StartPosition == true)
                {
                    if(ChessPiecePosition.X==7)
                    ValidMove.Add(new Position(ChessPiecePosition.X-1, ChessPiecePosition.Y - 1));
                    else if (ChessPiecePosition.X >= 0 && ChessPiecePosition.X < 7)
                    ValidMove.Add(new Position(ChessPiecePosition.X+1, ChessPiecePosition.Y - 1));
                    
                    
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y-1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 2));
                   
                }
                else if (StartPosition == false)
                {
                    if (ChessPiecePosition.X == 7)
                        ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y - 1));
                    else if (ChessPiecePosition.X >= 0 && ChessPiecePosition.X < 7)
                        ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y - 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 1));
                }
                
            }
            else// Black pieces
            {
                if (StartPosition == true)
                {
                    if (ChessPiecePosition.X ==7)
                    ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y + 1));
                    else if (ChessPiecePosition.X >= 0 && ChessPiecePosition.X < 7)
                    ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y + 1));
                    
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 2));
                    
                }
                else if (StartPosition == false)
                {
                    if (ChessPiecePosition.X == 7)
                    ValidMove.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y + 1));
                    else if (ChessPiecePosition.X >= 0 && ChessPiecePosition.X < 7)
                    ValidMove.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y + 1));
                    ValidMove.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
                }
                
            }

            return ValidMove;

        }
        public override string ToString()
        {
            return String.Format("P");
        }
    }
}
