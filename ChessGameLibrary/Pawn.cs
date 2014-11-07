using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class Pawn:IChessPiece
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



        List<Position> GetMoves(Player player)
        {
            List<Position> Moves = new List<Position>();
            if (player.PlayerId == ChessColor.White)
            {
                Moves.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 1));
                Moves.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y - 1));
                Moves.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y - 1));

                if (StartPosition == true)
                {
                    Moves.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 2));
                }
            }
            else
            {
                Moves.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
                Moves.Add(new Position(ChessPiecePosition.X - 1, ChessPiecePosition.Y + 1));
                Moves.Add(new Position(ChessPiecePosition.X + 1, ChessPiecePosition.Y + 1));

                if (StartPosition == true)
                {
                    Moves.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 2));
                }
            }

            return Moves;
        }

        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)
        {
            List<Position> Moves = GetMoves(currentPlayer);
            bool canMove = true;

            //Check if piece can move one step --------------------------
            if (Moves[1].Y < 0 || Moves[1].Y > 7)   //Checks if move is outside of chessboard
            {
                canMove = false;
            }
            else    //Checks if opponent is blocking
            {
                for (int i = 1; i < 16; i++)
                {
                    if (Moves[1] == Opponent.Pieces[i].ChessPiecePosition)
                        canMove = false;
                }
            }

            if (canMove == true)    //Adds move if valid
                ValidMove.Add(Moves[1]);


            //Check if piece can move two steps ------------------------
            if (StartPosition == true)
            {
                for (int i = 1; i < 16; i++)
                {
                    if (Moves[4] == Opponent.Pieces[i].ChessPiecePosition) //Checks if opponent is blocking
                        canMove = false;
                }
            }
            if (canMove == true)    //Adds move if valid
                ValidMove.Add(Moves[4]);


            //Check if piece can attack --------------------------------
            canMove = false;
            for (int i = 1; i < 16; i++)
            {
                if (Moves[2] == Opponent.Pieces[i].ChessPiecePosition)
                    canMove = true;
            }

            if (canMove == true)    //Adds move if valid
                ValidMove.Add(Moves[2]);


            //Check if piece can attack --------------------------------
            canMove = false;
            for (int i = 1; i < 16; i++)
            {
                if (Moves[3] == Opponent.Pieces[i].ChessPiecePosition)
                    canMove = true;
            }

            if (canMove == true)    //Adds move if valid
                ValidMove.Add(Moves[3]);


            return ValidMove;
        }
    }
}
