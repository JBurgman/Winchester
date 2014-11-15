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

        //Fields
        Player player1;
        Player player2;
        public Logger log = new Logger();

       
        
        // Properties
        public List<Player> PlayerList { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player OtherPlayer { get; set; }
        public List<IChessPiece> CapturedPieces { get; set; }


        //public List<IChessPiece> TakenPieces { get; set; } 
        public Player Opponent { get; set; }
        public List<IChessPiece> TakenPieces { get; set; }

        public ChessGame()
        {
            PlayerList = new List<Player>();
            player1 = new Player(ChessColor.White);
            player2 = new Player(ChessColor.Black);
            this.CurrentPlayer = player1;
            this.Opponent = player2;

            CapturedPieces = new List<IChessPiece>();

            logger = new Logger();
            CurrentPlayer = player1;
            OtherPlayer = player2;

            PlayerList.Add(player1);
            PlayerList.Add(player2);
        }

        // Methods



        public void InitializeChessPieceList() // Create chess pieces and store them in players lists. Done.
        {
            foreach (var player in PlayerList)
            {
                player.CreateChessPieceList();
            }
        }

        
        public void CalculateNextMove() //not done
        {
            Position nextPos = null;
            IChessPiece movingPiece = null;
        
            //Creates a list of pieces that can move
            List<IChessPiece> availablePieces = new List<IChessPiece>();
            for(int i = 0; i < CurrentPlayer.Pieces.Count; i++)
            {
                if (CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent).Count > 0)
                {
                    availablePieces.Add(CurrentPlayer.Pieces[i]);
            }




            //TODO:Put id back in the queue


            ChangePlayer();
        }
        
            //Creates a list of threatened pieces
            List<IChessPiece> threathenedPieces = new List<IChessPiece>();
            for (int i = 0; i < availablePieces.Count; i++)
            {
                if (CheckIfThreatened(availablePieces[i].PieceId) == true)
                    threathenedPieces.Add(CurrentPlayer.Pieces[i]);
            }
      
            //Creates list with the most prioritised pieces
            List<IChessPiece> prioritisedPieces = new List<IChessPiece>();

            if (threathenedPieces.Count > 0)
        {
                for (int i = 0; i < threathenedPieces.Count; i++)    //Prioritise threathened pieces that can attack 
                {
                    if (canAttack(threathenedPieces[i]) == true)
                        prioritisedPieces.Add(threathenedPieces[i]);
                }
            }
            else if (prioritisedPieces.Count == 0 && availablePieces.Count > 0)  //If none of the threathened pieces can attack
            {
                for (int i = 0; i < availablePieces.Count; i++)
                {
                    if (canAttack(availablePieces[i]) == true)
                    {
                        prioritisedPieces.Add(availablePieces[i]);
                    }
                }
            }

            //Calculate wich prioritised pice to move --------



            //------------------------------------------------


            //Temporary--------
            if (availablePieces.Count > 0)    //If no piece can attack
            {
                Random piece = new Random();
                int mPiece = piece.Next(0, availablePieces.Count);
 

                Random move = new Random();
                int randomMove = move.Next(0, availablePieces[mPiece].GetValidMove(CurrentPlayer, Opponent).Count);


                nextPos = availablePieces[mPiece].GetValidMove(CurrentPlayer, Opponent)[randomMove];

                movingPiece = availablePieces[mPiece];
            }

                Console.WriteLine(CurrentPlayer.Pieces[10].GetValidMove(CurrentPlayer, Opponent).Count);

            if (nextPos == null || movingPiece == null)
            {
                //Player cant move -> end game?
                Console.WriteLine("Cant move!");
            }
            else
            {
                log.Log(CurrentPlayer, movingPiece, movingPiece.ChessPiecePosition, nextPos);
                MovePiece(nextPos, movingPiece);
            }
            
            //Temporary ^^^^


            ChangePlayer(CurrentPlayer); //Switch opponent and currentplayer
        }

        bool canAttack(IChessPiece piece)
        {
            bool flag = false;



            List<Position> Moves = piece.GetValidMove(CurrentPlayer, Opponent);

            for (int i = 0; i < Opponent.Pieces.Count; i++)
            {
                for (int x = 0; x < Moves.Count; x++)
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
            for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
            { }


                return threatened;
        }


        void MovePiece(Position nextPosition, IChessPiece chessPiece)
        {
           // l.Log(CurrentPlayer, chessPiece, chessPiece.ChessPiecePosition, nextPosition);

            for (int i = 0; i < Opponent.Pieces.Count; i++)
            {
                if (Opponent.Pieces[i].ChessPiecePosition.X == nextPosition.X && Opponent.Pieces[i].ChessPiecePosition.Y == nextPosition.Y)
                    Opponent.Pieces.RemoveAt(i);
            }

            //Moves piece to new position
            chessPiece.ChessPiecePosition = nextPosition;

            
        }


        void ChangePlayer(Player player)
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

            this.CurrentPlayer = player; 
        }
    }
}
