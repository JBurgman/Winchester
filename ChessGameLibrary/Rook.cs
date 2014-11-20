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
        public bool StartPosition { get; set; }
        public PieceType PieceType { get; set; }
        public ChessColor PieceColor { get; set; }

        public Rook(Position chessPiecePosition, int pieceId, PieceType pieceType, ChessColor pieceColor)
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

            //Move Left
            for (int i = 1; i < 8; i++)
            {
                Moves.Add(new Position(this.ChessPiecePosition.X - i, this.ChessPiecePosition.Y));
            }

            //Move Right
            for (int i = 1; i < 8; i++)
            {
                Moves.Add(new Position(this.ChessPiecePosition.X + i, this.ChessPiecePosition.Y));
            }

            //Move Down
            for (int i = 1; i < 8; i++)
            {
                Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y + i));
            }

            //Move Up
            for (int i = 1; i < 8; i++)
            {
                Moves.Add(new Position(this.ChessPiecePosition.X, this.ChessPiecePosition.Y - i));
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

            for (int i = 0; i < 7; i++)
            {
                valid = true;
                lastMove = false;

                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                    {
                        lastMove = true;
                        goto left;
                    }
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        lastMove = true;
                        break;
                    }
                }

            left:

                //Check if outside border
                if (Moves[i].X < 0)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true) //Breaks after last valid move
                    break;
            }


            //Right ----------------------------------------

            for (int i = 7; i < 14; i++)
            {
                valid = true;
                lastMove = false;

                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                    {
                        lastMove = true;
                        goto right;
                    }
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        lastMove = true;
                        break;
                    }
                }

            right:

                //Check if outside border
                if (Moves[i].X > 7)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true) //Breaks after last valid move
                    break;
            }


            //Down -----------------------------------------


            for (int i = 14; i < 21 ; i++)
            {
                valid = true;
                lastMove = false;

                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                    {
                        lastMove = true;
                        goto down;
                    }
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        lastMove = true;
                        break;
                    }
                }

            down:
                //Check if outside border
                if (Moves[i].Y > 7)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true) //Breaks after last valid move
                    break;
            }


            //Up -------------------------------------------


            for (int i = 21; i < 28 ; i++)
            {
                valid = true;
                lastMove = false;

                //Checks square for opponent piece
                for (int x = 0; x < Opponent.Pieces.Count; x++)
                {
                    if (Moves[i].X == Opponent.Pieces[x].ChessPiecePosition.X && Moves[i].Y == Opponent.Pieces[x].ChessPiecePosition.Y)
                    {
                        lastMove = true;
                        goto up;
                    }
                }

                //Checks square for players piece
                for (int x = 0; x < currentPlayer.Pieces.Count; x++)
                {
                    if (Moves[i].X == currentPlayer.Pieces[x].ChessPiecePosition.X && Moves[i].Y == currentPlayer.Pieces[x].ChessPiecePosition.Y)
                    {
                        valid = false;
                        lastMove = true;
                        break;
                    }
                }

            up:

                //Check if outside border
                if (Moves[i].Y < 0)
                    valid = false;

                if (valid == true)
                    ValidMove.Add(Moves[i]);

                if (lastMove == true) //Breaks after last valid move
                    break;
            }

            return ValidMove; //Returns list with valid moves
        }

    }
}
