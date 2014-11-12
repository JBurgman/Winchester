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
            this.StartPosition = true;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
            this.PieceColor = pieceColor;
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
                for (int i = 1; i < Opponent.Pieces.Count; i++)
                {
                    if (Moves[0] == Opponent.Pieces[i].ChessPiecePosition)
                        valid = false;
                }

                for (int i = 1; i < currentPlayer.Pieces.Count; i++)
                {
                    if (Moves[0] == currentPlayer.Pieces[i].ChessPiecePosition)
                        valid = false;
                }
            }

            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[0]);


            //Check if piece can move two steps ------------------------
            if (StartPosition == true)
            {
                for (int i = 1; i < Opponent.Pieces.Count; i++)
                {
                    if (Moves[3] == Opponent.Pieces[i].ChessPiecePosition) //Checks if piece is blocking
                        valid = false;
                }

                for (int i = 1; i < currentPlayer.Pieces.Count; i++)
                {
                    if (Moves[3] == currentPlayer.Pieces[i].ChessPiecePosition) //Checks if piece is blocking
                        valid = false;
                }
            }
            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[3]);


            //Check if piece can attack --------------------------------
            valid = false;
            for (int i = 1; i < Opponent.Pieces.Count; i++)
            {
                if (Moves[1] == Opponent.Pieces[i].ChessPiecePosition)
                    valid = true;
            }

            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[1]);


            valid = false;
            for (int i = 1; i < Opponent.Pieces.Count; i++)
            {
                if (Moves[2] == Opponent.Pieces[i].ChessPiecePosition)
                    valid = true;
            }

            if (valid == true)    //Adds move if valid
                ValidMove.Add(Moves[2]);
            

            return ValidMove;
        }
    }
}
