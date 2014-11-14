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
        Logger logger;
        Queue<int> whitelist = new Queue<int>();
        Queue<int> blacklist = new Queue<int>();

        const int top = 0;
        const int bottom = 8;
        const int left = 0;
        const int right = 8;
       
        
        // Properties
        public List<Player> PlayerList { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player OtherPlayer { get; set; }
        public List<IChessPiece> CapturedPieces { get; set; }


        public List<IChessPiece> TakenPieces { get; set; } 

        public ChessGame()
        {
            PlayerList = new List<Player>();
            player1 = new Player(ChessColor.White);
            player2 = new Player(ChessColor.Black);

            CapturedPieces = new List<IChessPiece>();

            logger = new Logger();
            CurrentPlayer = player1;
            OtherPlayer = player2;

            PlayerList.Add(player1);
            PlayerList.Add(player2);

            InitializeWhiteList();
            InitializeBlackList();
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
        public void CalculateNextMove() //on going - called from ConsoleApplication
        {
            
            var id = 0;
            if (CurrentPlayer == player1)// White starts
            {
                // Get a piece and check if it can move can move 
                //id = 0;

                if (whitelist.Count > 0)
                {
                    //id = whitelist.Peek();
                    id = whitelist.Dequeue();// return first piece in queue.
                    whitelist.Enqueue(id);
                    id = id - 1;

                }
            }
            else // Black in turn
            {
                //var id = 0;

                // Get pieces that can move 
                if (blacklist.Count > 0)
                {
                    //id = blacklist.Peek();
                    id = blacklist.Dequeue();// return first piece in queue.
                    blacklist.Enqueue(id);
                    id = id - 1;
                }

            }
            // Get the piece from player list
            var chesspiece = CurrentPlayer.Pieces.ElementAt(id);

            var cantake = false;

            // Get the next position from valid moves
            var nextposition = chesspiece.GetValidMove().ElementAt(0);//Applies to Pawn

            //TODO:Check borders
            //if (nextposition.X >= 0 && nextposition.X < 7 && nextposition.Y >= 0 && nextposition.Y < 7)
            //{





                //TODO: Check if there is any black or white pieces in next position, if not: 
                for (int i = 0; i < OtherPlayer.Pieces.Count; i++)
                {
                    if ((OtherPlayer.Pieces[i].ChessPiecePosition.X == nextposition.X) && (OtherPlayer.Pieces[i].ChessPiecePosition.Y == nextposition.Y))
                    {
                        cantake = true;
                        var capturedPiece = OtherPlayer.Pieces[i];

                        CapturePiece(capturedPiece);
                        //CapturedPieces.Add(capturedPiece);
                        OtherPlayer.Pieces.Remove(capturedPiece);


                        //TODO:Remove from whitelist and blacklist
                        //if (CurrentPlayer == player1)
                        //{
                        //    id = blacklist.Dequeue();
                            
                        //}
                        //else
                        //{
                        //    id = whitelist.Dequeue();
                        //}
                    }

        }
            //}

        
            // Call MovePiece()
            //MovePiece(nextposition, chesspiece);


            //TODO:Check borders
            //if (nextposition.X >= 0 && nextposition.X < 7 && nextposition.Y >= 0 && nextposition.Y < 7)
            //{

                // Get the next position from valid moves
                if (!cantake)
        {
                    nextposition = chesspiece.GetValidMove().Last();//TODO:Fix ValidMoves in Pawn
                    //if (CurrentPlayer == player1)
                    //{
                    //    id = whitelist.Dequeue();// return first piece in queue.
                    //    whitelist.Enqueue(id);
                    //}
                    //else
                    //{
                    //     id = blacklist.Dequeue();// return first piece in queue.
                    //     blacklist.Enqueue(id);
                    //}
                    
                }


            //}
            //TODO:Check borders
            //if (nextposition.X >= 0 && nextposition.X < 7 && nextposition.Y >= 0 && nextposition.Y < 7)
            //{
                chesspiece.ChessPiecePosition = nextposition;
            //}


            if (chesspiece.StartPosition)// If in startposition
            {
                chesspiece.StartPosition = false;
            }




            //TODO:Put id back in the queue


            ChangePlayer();
            }

        private void CapturePiece(IChessPiece chessPiece)
        {
            CapturedPieces.Add(chessPiece);
            //OtherPlayer.Pieces.Remove(chessPiece);
           
        }

      







        bool CheckIfThreatened(int PieceId) //not done - optional
        {
            bool threatened = false;

            Player Opponent;
            if (CurrentPlayer.PlayerId == ChessColor.White)
                Opponent = player2;
            else
                Opponent = player1;

            for (int i = 1; i < 16; i++)
            {
                
            }

                return threatened;
        }


        void MovePiece(Position nextPosition, IChessPiece chessPiece)
        {
            //Check if opponents piece gets taken
            Player Opponent;
            if (CurrentPlayer.PlayerId == ChessColor.White)
                Opponent = player2;
            else
                Opponent = player1;

            for (int i = 0; i < 16; i++)
            {
                if (Opponent.Pieces[i].ChessPiecePosition == nextPosition)
                    Opponent.Pieces[i].ChessPiecePosition = null;
            }

            //Moves piece to new position
            CurrentPlayer.Pieces[chessPiece.PieceId].ChessPiecePosition = nextPosition;
        }


        private void ChangePlayer() // Change player. Done.
        {
            if (CurrentPlayer.PlayerId == player1.PlayerId)
        {
                CurrentPlayer = player2;
                OtherPlayer = player1;
            }
            else
            {
                CurrentPlayer = player1;
                OtherPlayer = player2;
            }
        }
        void InitializeWhiteList() // Start with pawns
        {
            for (int i = 0; i < 8; i++)
            {
                whitelist.Enqueue(i + 1);
            }
        }
    }
}
