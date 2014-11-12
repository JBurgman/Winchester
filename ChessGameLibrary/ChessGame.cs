using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public enum ChessColor
    {
        White,
        Black

    }
    public class ChessGame
    {
        //
        //Fields
        Player player1;
        Player player2;
        public Logger l = new Logger();


        
        // Properties
        public List<Player> PlayerList { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player Opponent { get; set; }

        public List<string> LogPost { get; set; } 

        public ChessGame()
        {
            PlayerList = new List<Player>();
            player1 = new Player(ChessColor.White);
            player2 = new Player(ChessColor.Black);
            CurrentPlayer = player1;

            PlayerList.Add(player1);
            PlayerList.Add(player2);
        }

        // Methods

        public void InitializeChessPieceList() //not done
        {
            foreach (var player in PlayerList)
            {
                player.CreateChessPieceList();
            }
        }

        //
        void CalculateNextMove() //not done
        {
            Position nextPos = null;

            //Creates a list of pieces that can move
            List<IChessPiece> availablePieces = new List<IChessPiece>();
            for(int i = 0; i < CurrentPlayer.Pieces.Count; i++)
            {
                if (CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent).Count > 0)
                {
                    availablePieces.Add(availablePieces[i]);
                }
            }

            //Creates a list of threatened pieces
            List<IChessPiece> threathenedPieces = new List<IChessPiece>();
            for (int i = 1; i < availablePieces.Count; i++)
            {
                if (CheckIfThreatened(availablePieces[i].PieceId) == true)
                    threathenedPieces.Add(CurrentPlayer.Pieces[i]);
            }
      
            //Creates list with the most prioritised pieces
            List<IChessPiece> prioritisedPieces = new List<IChessPiece>();

            if (threathenedPieces.Count > 0)
            {
                for (int i = 1; i < threathenedPieces.Count; i++)    //Prioritise threathened pieces that can attack 
                {
                    if (canAttack(threathenedPieces[i].PieceId) == true)
                        prioritisedPieces.Add(threathenedPieces[i]);
                }
            }
            else if (prioritisedPieces.Count == 0)                //If none of the threathened pieces can attack
            {
                for (int i = 1; i < availablePieces.Count; i++)
                {
                    if (canAttack(availablePieces[i].PieceId) == true)
                    {
                        prioritisedPieces.Add(availablePieces[i]);
                    }
                }
            }

            //Calculate wich prioritised pice to move --------



            //------------------------------------------------

            //Temporary--------
            if (prioritisedPieces.Count == 0)                     //If no piece can attack
            {
                Random id = new Random();
                int randomID = id.Next(0, availablePieces.Count);

                nextPos = CurrentPlayer.Pieces[randomID].GetValidMove(CurrentPlayer, Opponent)[0];
            }
            else
            {
                List<Position> Moves = CurrentPlayer.Pieces[prioritisedPieces[0].PieceId].GetValidMove(CurrentPlayer, Opponent);

                for (int i = 1; i < Opponent.Pieces.Count; i++)
                {
                    for (int x = 1; x < Moves.Count; x++)
                    {
                        if (Moves[x] == Opponent.Pieces[i].ChessPiecePosition)
                        {
                            nextPos = Opponent.Pieces[i].ChessPiecePosition;
                        }
                    }
                }
            }

            if (nextPos == null)
            {
                //Player cant move -> end game?
            }
            else
            {
                MovePiece(nextPos, CurrentPlayer.Pieces[0]);
            }
            
            //Temporary ^^^^
            

 
        }

        bool canAttack(int pieceID)
        {
            bool flag = false;

            List<Position> Moves = CurrentPlayer.Pieces[pieceID].GetValidMove(CurrentPlayer, Opponent);
            for (int i = 1; i < Opponent.Pieces.Count; i++)
            {
                for (int x = 1; x < Moves.Count; x++)
                {
                    if (Moves[x] == Opponent.Pieces[i].ChessPiecePosition)
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }
        
        bool CheckIfThreatened(int PieceId)
        {
            bool threatened = false;

            //Loops through opponents pieces
            for (int i = 1; i < CurrentPlayer.Pieces.Count; i++)
            {
                
                List<Position> OpponentMoves = Opponent.Pieces[i].GetValidMove(CurrentPlayer, Opponent);

                for (int x = 1; x < Opponent.Pieces[i].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                {
                    //Checks if opponents piece threatens
                    if (CurrentPlayer.Pieces[PieceId].ChessPiecePosition == OpponentMoves[x])
                        threatened = true;
                }
            }

                return threatened;
        }


        void MovePiece(Position nextPosition, IChessPiece chessPiece)
        {
            //Check if opponents pice gets taken
            for (int i = 1; i < Opponent.Pieces.Count; i++)
            {
                if (Opponent.Pieces[i].ChessPiecePosition == nextPosition)
                    Opponent.Pieces[i].ChessPiecePosition = null;
            }

            //Moves piece to new position
            CurrentPlayer.Pieces[chessPiece.PieceId].ChessPiecePosition = nextPosition;
        }


        public void ChangePlayer(Player player)
        {
            if (player.PlayerId == ChessColor.White)
            {
                this.CurrentPlayer = player2;
                this.Opponent = player1;
            }
            else
            {
                this.CurrentPlayer = player1; 
                this.Opponent = player2;
            }

        }
    }
}
