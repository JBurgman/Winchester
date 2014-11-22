using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class King : IChessPiece
    {
        public Position ChessPiecePosition { get; set; }
        public bool StartPosition { get; set; }
        public int PieceId { get; set; }
        public bool StartPosition { get; set; }
        public PieceType PieceType { get; set; }
        public ChessColor PieceColor { get; set; }

        public King(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
            this.PieceColor = pieceColor;
            this.StartPosition = true;
        }

        /// <summary>
        ///  GetMoves är en lista över hur en pjäs kan röra sig.
        /// </summary>
        /// <returns></returns>
        public List<Position> GetMoves()
        {
            List<Position> Moves = new List<Position>();

            //Move Left
            Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y));
        
            //Move Right
            Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y));

            //Move Down
            Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y + 1));

            //Move Up
            Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y - 1));

            //Move S-E
            Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y + 1));

            //Move S-W
            Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y + 1));

            //Move N-E
            Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y - 1));

            //Move N-W
            Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y - 1));

            return Moves;
        }


        //Valid moves for this piece
        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)
        {
            List<Position> ValidMove = new List<Position>();
            List<Position> Moves = GetMoves();

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
            return String.Format("K");
        }
    }
}