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
        public bool GameOver = false;
        public List<Player> PlayerList { get; set; }
        public Player CurrentPlayer { get; set; }
        public Player Opponent { get; set; }
        public List<IChessPiece> TakenPieces { get; set; }

        public ChessGame()
        {
            PlayerList = new List<Player>();
            player1 = new Player(ChessColor.White);
            player2 = new Player(ChessColor.Black);
            this.CurrentPlayer = player1;
            this.Opponent = player2;

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
            }

            //Creates a list of threatened pieces
            List<IChessPiece> threathenedPieces = new List<IChessPiece>();
            for (int i = 0; i < availablePieces.Count; i++)
            {
                if (CheckIfThreatened(availablePieces[i].ChessPiecePosition) == true)
                    threathenedPieces.Add(CurrentPlayer.Pieces[i]);
            }
      
            //Creates list with the most prioritised pieces
            List<IChessPiece> prioritisedPieces = new List<IChessPiece>();

            if (threathenedPieces.Count != 0)
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
                        prioritisedPieces.Add(availablePieces[i]);
                }
            }

            //Calculate wich prioritised pice to move --------
            

            if(CheckIfChecked() == true) //If king is checked
            {
                List<IChessPiece> Blockers = new List<IChessPiece>();
                List<IChessPiece> Attackers = new List<IChessPiece>();

                //Get king listPos ---------------------------------------------------
                int king = 0;
                for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
                {
                    if(CurrentPlayer.Pieces[i].PieceType == PieceType.King)
                        king = i;
                }
                // -------------------------------------------------------------------

                //Get threat ---------------------------------------------------------
                IChessPiece threat = null;
                int threatX = 0, threatY = 0;
                for (int i = 0; i < Opponent.Pieces.Count; i++)
                {
                    for (int x = 0; x < Opponent.Pieces[i].GetValidMove(Opponent, CurrentPlayer).Count; x++)
                    {
                        if (CurrentPlayer.Pieces[king].ChessPiecePosition.X == Opponent.Pieces[i].GetValidMove(Opponent, CurrentPlayer)[x].X && CurrentPlayer.Pieces[king].ChessPiecePosition.Y == Opponent.Pieces[i].GetValidMove(Opponent, CurrentPlayer)[x].Y)
                        {
                            threat = Opponent.Pieces[i];
                            threatX = threat.ChessPiecePosition.X;
                            threatY = threat.ChessPiecePosition.Y;
                        }
                    }
                }
                // -------------------------------------------------------------------

                //Check if pieces can attack threat -> add to Attackers --------------
                

                for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
                {
                    for (int x = 0; x < CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                    {
                        if (threat.ChessPiecePosition.X == CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent)[x].X && threat.ChessPiecePosition.Y == CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent)[x].Y)
                        {
                            int tempX = CurrentPlayer.Pieces[i].ChessPiecePosition.X;
                            int tempY = CurrentPlayer.Pieces[i].ChessPiecePosition.Y;


                            MovePiece(threat.ChessPiecePosition, CurrentPlayer.Pieces[i]);

                            if (CheckIfChecked() == true)
                            {
                                CurrentPlayer.Pieces[i].ChessPiecePosition.X = tempX;
                                CurrentPlayer.Pieces[i].ChessPiecePosition.Y = tempY;
                            }
                            else
                            {
                                CurrentPlayer.Pieces[i].ChessPiecePosition.X = tempX;
                                CurrentPlayer.Pieces[i].ChessPiecePosition.Y = tempY;
                                Attackers.Add(CurrentPlayer.Pieces[i]);
                            }

                            threat.ChessPiecePosition.X = threatX;
                            threat.ChessPiecePosition.Y = threatY;
                            Opponent.Pieces.Add(threat);
                        }
                    }
                }

                // --------------------------------------------------------------------

                //If no piece can attack -> Check if king can move --------------------
                if (Attackers.Count == 0)
                {
                    //Check for safe square and set next random next pos
                    for (int i = 0; i < CurrentPlayer.Pieces[king].GetValidMove(CurrentPlayer, Opponent).Count; i++)
                    {
                        if (CheckIfThreatened(CurrentPlayer.Pieces[king].GetValidMove(CurrentPlayer, Opponent)[i], CurrentPlayer.Pieces[king]) != true)
                        {
                            movingPiece = CurrentPlayer.Pieces[king];
                            nextPos = CurrentPlayer.Pieces[king].GetValidMove(CurrentPlayer, Opponent)[i];
                        }
                    }

                    //Checks if can attack square and replace next pos
                    for (int i = 0; i < Opponent.Pieces.Count; i++)
                    {
                        for (int x = 0; x < CurrentPlayer.Pieces[king].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                        {
                            if(CurrentPlayer.Pieces[king].GetValidMove(CurrentPlayer, Opponent)[x].X == Opponent.Pieces[i].ChessPiecePosition.X && CurrentPlayer.Pieces[king].GetValidMove(CurrentPlayer, Opponent)[x].Y == Opponent.Pieces[i].ChessPiecePosition.Y)
                            {
                                if (CheckIfThreatened(Opponent.Pieces[i].ChessPiecePosition) != true)
                                    nextPos = Opponent.Pieces[i].ChessPiecePosition;
                            }
                        }
                    }
                }
                else
                {
                    // --------------------------------------------------------------------

                    //Can block threat?
                   
                    for (int i = 0; i < CurrentPlayer.Pieces.Count; i++ )
                    {
                        for (int x = 0; x < CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                        {
                            int tempX = CurrentPlayer.Pieces[i].ChessPiecePosition.X;
                            int tempY = CurrentPlayer.Pieces[i].ChessPiecePosition.Y;

                            MovePiece(CurrentPlayer.Pieces[i].GetValidMove(CurrentPlayer, Opponent)[x], CurrentPlayer.Pieces[i], true);

                            if (CheckIfChecked() != true)
                            {
                                CurrentPlayer.Pieces[i].ChessPiecePosition.X = tempX;
                                CurrentPlayer.Pieces[i].ChessPiecePosition.Y = tempY;
                                Blockers.Add(CurrentPlayer.Pieces[i]);
                            }
                            else
                            {
                                CurrentPlayer.Pieces[i].ChessPiecePosition.X = tempX;
                                CurrentPlayer.Pieces[i].ChessPiecePosition.Y = tempY;
                            }
                        }

                    }
                }

                
                if (Attackers.Count != 0) //Attack threat
                {
                    movingPiece = Attackers[0];
                    nextPos = threat.ChessPiecePosition;
                }
                else if(Blockers.Count != 0) //Block threat - Selects the blocker with least value // DOES IT WORK?
                {
                    int blocker = 0;

                    //for (int i = 0; i < Attackers.Count; i++)
                    //{
                    //    if (Blockers[i].PieceType < Blockers[blocker].PieceType)
                    //    {
                    //        blocker = i;
                    //    }
                    //}


                    for (int x = 0; x < Blockers[blocker].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                    {
                        int tempX = Blockers[blocker].ChessPiecePosition.X;
                        int tempY = Blockers[blocker].ChessPiecePosition.Y;


                        MovePiece(Blockers[blocker].GetValidMove(CurrentPlayer, Opponent)[x], Blockers[blocker], true);

                        if (CheckIfChecked() != true)
                        {
                            Blockers[blocker].ChessPiecePosition.X = tempX;
                            Blockers[blocker].ChessPiecePosition.Y = tempY;
                            nextPos = Blockers[blocker].GetValidMove(CurrentPlayer, Opponent)[x];
                        }
                        else
                        {
                            Blockers[blocker].ChessPiecePosition.X = tempX;
                            Blockers[blocker].ChessPiecePosition.Y = tempY;
                        }
                    }

                    movingPiece = Blockers[blocker];
                }
                else
                {
                    goto end; //Game over
                }


            }
            else if (prioritisedPieces.Count != 0) //If there is prioritised pieces
            {
                IChessPiece target = Opponent.Pieces[0]; //Temp target
                for (int i = 0; i < prioritisedPieces.Count; i++)
                {
                    for (int x = 0; x < prioritisedPieces[i].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                    {
                        for (int n = 0; n < Opponent.Pieces.Count; n++)
                        {
                            if (prioritisedPieces[i].GetValidMove(CurrentPlayer, Opponent)[x].X == Opponent.Pieces[n].ChessPiecePosition.X && prioritisedPieces[i].GetValidMove(CurrentPlayer, Opponent)[x].Y == Opponent.Pieces[n].ChessPiecePosition.Y)
                            {
                                if (Opponent.Pieces[n].PieceType.CompareTo(target.PieceType) >= 0)
                                {
                                    target = Opponent.Pieces[n];
                                    movingPiece = prioritisedPieces[i];
                                    nextPos = target.ChessPiecePosition;
                                }
                            }
                        }
                    }
                }

            }
            else if (availablePieces.Count == 0)
            {
                goto end;
            }
            else
            {
   
                int mPiece = 0;
                int randomMove = 0;

                if (availablePieces.Count > 1)
                {
                re:
                    Random piece = new Random();
                    mPiece = piece.Next(0, availablePieces.Count);

                    if (availablePieces[mPiece].PieceType == PieceType.King)
                        goto re;

                    if (availablePieces[mPiece].GetValidMove(CurrentPlayer, Opponent).Count > 1)
                    {
                        Random move = new Random();
                        randomMove = move.Next(0, availablePieces[mPiece].GetValidMove(CurrentPlayer, Opponent).Count - 1);
                    }

                    

                    //Check if valid
                    int tempX = availablePieces[mPiece].ChessPiecePosition.X;
                    int tempY = availablePieces[mPiece].ChessPiecePosition.Y;

                    MovePiece(availablePieces[mPiece].GetValidMove(CurrentPlayer, Opponent)[randomMove], availablePieces[mPiece], true);

                    if (CheckIfChecked() == true)
                    {
                        availablePieces[mPiece].ChessPiecePosition.X = tempX;
                        availablePieces[mPiece].ChessPiecePosition.Y = tempY;
                        goto re;
                    }
                    else
                    {
                        availablePieces[mPiece].ChessPiecePosition.X = tempX;
                        availablePieces[mPiece].ChessPiecePosition.Y = tempY;
                    }

          
                    nextPos = availablePieces[mPiece].GetValidMove(CurrentPlayer, Opponent)[randomMove];
                    movingPiece = availablePieces[mPiece];
                }
                else if (availablePieces.Count == 1)//If king
                {
                    //Check for safe square and set next random next pos
                    for (int i = 0; i < availablePieces[0].GetValidMove(CurrentPlayer, Opponent).Count; i++)
                    {
                        if (CheckIfThreatened(availablePieces[0].GetValidMove(CurrentPlayer, Opponent)[i], availablePieces[0]) != true)
                        {
                            movingPiece = availablePieces[0];
                            nextPos = availablePieces[0].GetValidMove(CurrentPlayer, Opponent)[i];
                        }
                    }

                    //Checks if can attack square and replace next pos
                    for (int i = 0; i < Opponent.Pieces.Count; i++)
                    {
                        for (int x = 0; x < availablePieces[0].GetValidMove(CurrentPlayer, Opponent).Count; x++)
                        {
                            if (availablePieces[0].GetValidMove(CurrentPlayer, Opponent)[x].X == Opponent.Pieces[i].ChessPiecePosition.X && availablePieces[0].GetValidMove(CurrentPlayer, Opponent)[x].Y == Opponent.Pieces[i].ChessPiecePosition.Y)
                            {
                                if (CheckIfThreatened(Opponent.Pieces[i].ChessPiecePosition) != true)
                                    nextPos = Opponent.Pieces[i].ChessPiecePosition;
                            }
                        }
                    }
                }
                else
                {
                    //Cant move
                }
                
            }

        end:
            if (nextPos == null || movingPiece == null)
            {
                GameOver = true;
            }
            else
            {
                log.Log(CurrentPlayer, movingPiece, movingPiece.ChessPiecePosition, nextPos);
                MovePiece(nextPos, movingPiece);
            }


            ChangePlayer(CurrentPlayer); //Switch opponent and currentplayer
        }

        // Check if piece can attack ----------------------------------------------------
        bool canAttack(IChessPiece piece)
        {
            bool flag = false;

            List<Position> Moves = piece.GetValidMove(CurrentPlayer, Opponent);

            for (int i = 0; i < Opponent.Pieces.Count; i++)
            {
                for (int x = 0; x < Moves.Count; x++)
                {
                    if (Moves[x].X == Opponent.Pieces[i].ChessPiecePosition.X && Moves[x].Y == Opponent.Pieces[i].ChessPiecePosition.Y)
                    {
                        flag = true;
                    }
                }
            }

            return flag;
        }
        
        // Check if thretened ---------------------------------------------------------
        bool CheckIfThreatened(Position pos, IChessPiece piece = null)
        {
            bool threatened = false;
            Position tempPos = null;

            //Set temporary pos
            if (piece != null)
            {
                tempPos = piece.ChessPiecePosition;
                piece.ChessPiecePosition = pos;
            }
                

            //Loops through opponents pieces
            for (int i = 0; i < Opponent.Pieces.Count; i++)
            {

                //If Pawn
                if (Opponent.Pieces[i].PieceType == PieceType.Pawn)
                {
                    if (CurrentPlayer.PlayerId == ChessColor.White)
                    {
                        if ((pos.X == Opponent.Pieces[i].ChessPiecePosition.X - 1 && pos.Y == Opponent.Pieces[i].ChessPiecePosition.Y + 1) || (pos.X == Opponent.Pieces[i].ChessPiecePosition.X + 1 && pos.Y == Opponent.Pieces[i].ChessPiecePosition.Y + 1))
                        {
                            threatened = true;
                        }
                    }
                    else
                    {
                        if ((pos.X == Opponent.Pieces[i].ChessPiecePosition.X - 1 && pos.Y == Opponent.Pieces[i].ChessPiecePosition.Y - 1) || (pos.X == Opponent.Pieces[i].ChessPiecePosition.X + 1 && pos.Y == Opponent.Pieces[i].ChessPiecePosition.Y - 1))
                        {
                            threatened = true;
                        }
                    }
                    
                }
                else
                {
                    for (int x = 0; x < Opponent.Pieces[i].GetValidMove(Opponent, CurrentPlayer).Count; x++)
                    {
                        if (pos.X == Opponent.Pieces[i].GetValidMove(Opponent, CurrentPlayer)[x].X && pos.Y == Opponent.Pieces[i].GetValidMove(Opponent, CurrentPlayer)[x].Y)
                            threatened = true;
                    }
                }
            }

            if (piece != null)
                piece.ChessPiecePosition = tempPos;

            return threatened;
        }

        // Check if checked ---------------------------------------------------------
        bool CheckIfChecked()
        {
            bool flag = false;

            for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
            {
                if (CurrentPlayer.Pieces[i].PieceType == PieceType.King)
                {
                    if (CheckIfThreatened(CurrentPlayer.Pieces[i].ChessPiecePosition) == true)
                        flag = true;
                }
            }
                return flag;
        }

        // Move piece -----------------------------------------------------------------
        void MovePiece(Position nextPosition, IChessPiece chessPiece, bool temp = false)
        {

            //Startposition
            if (chessPiece.StartPosition == true)
                chessPiece.StartPosition = false;

            //Remove possible attacked piece if final move is done
            if (temp != true)
            {
                for (int i = 0; i < Opponent.Pieces.Count; i++)
                {
                    if (Opponent.Pieces[i].ChessPiecePosition.X == nextPosition.X && Opponent.Pieces[i].ChessPiecePosition.Y == nextPosition.Y)
                        Opponent.Pieces.RemoveAt(i);
                }



                //Promote -- Temp - (ID?)
                if (chessPiece.PieceType == PieceType.Pawn && (nextPosition.Y == 0 || nextPosition.Y == 7))
                {
                    for (int i = 0; i < CurrentPlayer.Pieces.Count; i++)
                    {
                        if (CurrentPlayer.Pieces[i] == chessPiece)
                            CurrentPlayer.Pieces.RemoveAt(i);
                    }
                    
                    CurrentPlayer.Pieces.Add(new Queen(new Position(nextPosition.X, nextPosition.Y), 12, PieceType.Queen, chessPiece.PieceColor));
                }
            }

            //Moves piece to new position
            chessPiece.ChessPiecePosition.X = nextPosition.X;
            chessPiece.ChessPiecePosition.Y = nextPosition.Y;
        }

        // Changeplayer -------------------------------------------------------------------
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
        }
    }
}
