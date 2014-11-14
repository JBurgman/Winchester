using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Bishop : IChessPiece
    {
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }
        public ChessColor PieceColor { get; set; }

        public Bishop(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
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
            
            //Add S-E moves
            for (int i = 0; i < 7; i++)
            {
                    Moves.Add(new Position(ChessPiecePosition.X + i, ChessPiecePosition.Y + i));
            }

            //Add S-W moves
            for (int i = 0; i < 7; i++)
            {
                Moves.Add(new Position(ChessPiecePosition.X - i, ChessPiecePosition.Y + i));
            }

            //Add N-E moves
            for (int i = 0; i < 7; i++)
            {
                Moves.Add(new Position(ChessPiecePosition.X + i, ChessPiecePosition.Y - i));
            }

            //Add N-W moves
            for (int i = 0; i < 7; i++)
            {
                    Moves.Add(new Position(ChessPiecePosition.X - i, ChessPiecePosition.Y - i));
            }
            
            return Moves;
        }


        //Valid moves for this piece
        public List<Position> GetValidMove(Player currentPlayer, Player Opponent)
        {
            List<Position> ValidMove = new List<Position>();
            List<Position> Moves = GetMoves();


            //S-E -----------------------------------------

            bool valid = true;
            bool lastMove = false;

            for (int i = 0; i < 7; i++)
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
                if (Moves[i].X > 7 || Moves[i].Y > 7)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].X == 7 || Moves[i].Y == 7) //Breaks after last valid move
                    break;
            }


            //S-W ----------------------------------------

            valid = true;
            lastMove = false;

            for (int i = 0; i < 7; i++)
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
                if (Moves[i].X < 0 || Moves[i].Y > 7)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].X == 0 || Moves[i].Y == 7) //Breaks after last valid move
                    break;
            }


            //N-E -----------------------------------------

            valid = true;
            lastMove = false;

            for (int i = 0; i < 7; i++)
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
                if (Moves[i].X > 7 || Moves[i].Y < 0)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].X == 7 || Moves[i].Y == 0) //Breaks after last valid move
                    break;
            }


            //N-W -------------------------------------------

            valid = true;
            lastMove = false;

            for (int i = 0; i < 7; i++)
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
                if (Moves[i].X < 0 || Moves[i].Y < 0)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true || Moves[i].X == 0 || Moves[i].Y == 0) //Breaks after last valid move
                    break;
            }

            return ValidMove; //Returns list with valid moves
        }
    }
}
