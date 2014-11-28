using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Knight : IChessPiece
    {


        public Position ChessPiecePosition { get; set; }
        public bool StartPosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }
        public ChessColor PieceColor { get; set; }

        public Knight(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
            this.PieceColor = pieceColor;
            this.StartPosition = true;
        }

        //Possible moves for this piece
        public List<Position> GetMoves()
        {
            List<Position> Moves = new List<Position>();
            {
                Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y - 2));
                Moves.Add(new Position(this.ChessPiecePosition.X + 2, this.ChessPiecePosition.Y - 1));
                Moves.Add(new Position(this.ChessPiecePosition.X + 2, this.ChessPiecePosition.Y + 1));
                Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y + 2));
                Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y + 2));
                Moves.Add(new Position(this.ChessPiecePosition.X - 2, this.ChessPiecePosition.Y + 1));
                Moves.Add(new Position(this.ChessPiecePosition.X - 2, this.ChessPiecePosition.Y - 1));
                Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y - 2));
            }
            return Moves;
        }

        //Valid moves for this piece
        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)
        {
            List<Position> Moves = GetMoves();
            List<Position> ValidMove = new List<Position>();

            bool valid = true;

            //Loops trough possible moves
            for (int i = 0; i < Moves.Count; i++)
            {
                valid = true;

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                        valid = false;
                }

                //Checks if inside of borders
                if (Moves[i].X < 0 || Moves[i].Y < 0 || Moves[i].X > 7 || Moves[i].Y > 7)
                    valid = false;


                //Add move if valid
                if (valid == true)
                    ValidMove.Add(Moves[i]);
            }


            return ValidMove; //Returns list with valid moves
        }

        public override string ToString()
        {
            return String.Format("S");
        }


    }
}
