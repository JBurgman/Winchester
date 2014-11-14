using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class Pawn:IChessPiece
    {
        public bool StartPosition { get; set; }
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }
        public ChessColor PieceColor { get; set; }

        public Pawn(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.StartPosition = false;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
            this.PieceColor = pieceColor;
        }



        List<Position> GetMoves(Player player)
        {
            List<Position> Moves = new List<Position>();

            if (player.PlayerId == ChessColor.White)
            {
                Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y - 1));
                Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y - 1));
                Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y - 1));

                if (StartPosition == true)
                {
                    Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y - 2));
                }
            }
            else
            {
                Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y + 1));
                Moves.Add(new Position(this.ChessPiecePosition.X - 1, this.ChessPiecePosition.Y + 1));
                Moves.Add(new Position(this.ChessPiecePosition.X + 1, this.ChessPiecePosition.Y + 1));

                if (StartPosition == true)
                {
                    Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y + 2));
                }
            }

            return Moves;
        }

        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)  //TODO: Can be made easier?
        {
            List<Position> ValidMove = new List<Position>();
            List<Position> Moves = GetMoves(currentPlayer);


            bool valid = true;

            
            //Check if piece can move one step --------------------------
            if (Moves[0].Y < 0 || Moves[0].Y > 7)   //Checks if move is outside of chessboard
            {
                valid = false;
            }
            else    //Checks if piece is blocking
            {
                for (int i = 0; i < Opponent.Pieces.Count; i++)
                {
                    if (Moves[0].X == Opponent.Pieces[i].ChessPiecePosition.X && Moves[0].Y == Opponent.Pieces[i].ChessPiecePosition.Y)
                        valid = false;
                }

                for (int i = 0; i < currentPlayer.Pieces.Count; i++)
                {
                    if (Moves[0].X == currentPlayer.Pieces[i].ChessPiecePosition.X && Moves[0].Y == currentPlayer.Pieces[i].ChessPiecePosition.Y)
                        valid = false;
                }
            }

            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[0]);


            //Check if piece can move two steps ------------------------
            if (StartPosition == true)
            {
                for (int i = 0; i < Opponent.Pieces.Count; i++)
                {
                    if (Moves[3].X == Opponent.Pieces[i].ChessPiecePosition.X && Moves[3].Y == Opponent.Pieces[i].ChessPiecePosition.Y) //Checks if piece is blocking
                        valid = false;
                }

                for (int i = 0; i < currentPlayer.Pieces.Count; i++)
                {
                    if (Moves[3].X == currentPlayer.Pieces[i].ChessPiecePosition.X && Moves[3].Y == currentPlayer.Pieces[i].ChessPiecePosition.Y) //Checks if piece is blocking
                        valid = false;
                }

                if (valid == true)    //Adds move if valid
                    ValidMove.Add(Moves[3]);
            }

            //Check if piece can attack --------------------------------
            valid = false;
            for (int i = 0; i < Opponent.Pieces.Count; i++)
            {
                if (Moves[1].X == Opponent.Pieces[i].ChessPiecePosition.X && Moves[1].Y == Opponent.Pieces[i].ChessPiecePosition.Y)
                    valid = true;
            }

            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[1]);


            valid = false;
            for (int i = 0; i < Opponent.Pieces.Count; i++)
            {
                if (Moves[2].X == Opponent.Pieces[i].ChessPiecePosition.X && Moves[2].Y == Opponent.Pieces[i].ChessPiecePosition.Y)
                    valid = true;
            }

            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[2]);


            return ValidMove;
        }
    }
}
