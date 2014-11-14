using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Rook:IChessPiece
    {
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }
        public ChessColor PieceColor { get; set; }

        public Rook(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
        {
            this.ChessPiecePosition = chessPiecePosition;
            this.PieceId = pieceId;
            this.PieceType = pieceType;
            this.PieceColor = pieceColor;
        }



        //Possible moves for this piece
        public List<Position> GetMoves()
        {
            List<Position> Moves = new List<Position>();

            //Move Left
            for (int i = 0; i < 7; i++)
            {
                Moves.Add(new Position(ChessPiecePosition.X - i, ChessPiecePosition.Y));
            }

            //Move Right
            for (int i = 0; i < 7; i++)
            {
                Moves.Add(new Position(ChessPiecePosition.X + i, ChessPiecePosition.Y));
            }

            //Move Down
            for (int i = 0; i < 7; i++)
            {
                Moves.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y + 1));
            }

            //Move Up
            for (int i = 0; i < 7; i++)
            {
                Moves.Add(new Position(ChessPiecePosition.X, ChessPiecePosition.Y - 1));
            }

                return Moves;

        }




        //Valid moves for this piece
        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)
        {
            List<Position> ValidMove = new List<Position>();
            List<Position> Moves = GetMoves();


            //Left -----------------------------------------

            bool valid = true;
            bool lastMove = false;

            for (int i = 1; i < 7; i++)
            {
                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                        lastMove = true;
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false; 
                        break;
                    }
                }

                //Check if outside border
                if (Moves[i].X < 0)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].X == 0) //Breaks after last valid move
                    break;
            }


            //Right ----------------------------------------

            valid = true;
            lastMove = false;

            for (int i = 7; i > 14; i++)
            {
                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                        lastMove = true;
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        break;
                    }
                }


                //Check if outside border
                if (Moves[i].X > 7)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].X == 7) //Breaks after last valid move
                    break;
            }


            //Down -----------------------------------------

            valid = true;
            lastMove = false;

            for (int i = 14; i < 21 ; i++)
            {
                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                        lastMove = true;
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        break;
                    }
                }

                //Check if outside border
                if (Moves[i].Y > 7)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].Y == 7) //Breaks after last valid move
                    break;
            }


            //Up -------------------------------------------

            valid = true;
            lastMove = false;

            for (int i = 21; i < 28 ; i++)
            {
                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                        lastMove = true;
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        break;
                    }
                }


                //Check if outside border
                if (Moves[i].Y < 0)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].Y == 0) //Breaks after last valid move
                    break;
            }

            return ValidMove; //Returns list with valid moves
        }

    }
}
