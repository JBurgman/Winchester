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

        
        public void CalculateNextMove() //not done
        {
            for (int i = 1; i < 16; i++)
            {
                CheckIfThreatened(CurrentPlayer.Pieces[i].PieceId);
            }
        }

      
        bool CheckIfThreatened(int PieceId) //not done
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
            //Check if opponents pice gets taken
            Player Opponent;
            if (CurrentPlayer.PlayerId == ChessColor.White)
                Opponent = player2;
            else
                Opponent = player1;

            for (int i = 1; i < 16; i++)
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
                player = player2;
            else
                player = player1;

            this.CurrentPlayer = player; 
        }
    }
}
