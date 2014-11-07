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

        //Test------------------------
        int whitepositionY = 1;
        int blackpositionY = 6;
        int i = 0;
        //----------------------------

        // Properties
        public List<Player> PlayerList { get; set; }
        public Player CurrentPlayer { get; set; }

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
        /// <summary>
        /// Method for initialization of each players list of pieces
        /// </summary>
        public void InitializeChessPieceList()
        {
            foreach (var player in PlayerList)
            {
                player.CreateChessPieceList();
            }

        }

        void CalculateNextMove() { }

        void CheckIfThretened() { }

        void MovePiece(Position nextPosition)
        {


        }

        void ChangePlayer()
        {
            if (CurrentPlayer.PlayerId == player1.PlayerId)
            {
                CurrentPlayer = player2;
            }
            else
            {
                CurrentPlayer = player1;
            }

        }

        public void NextMove()// Called from gameloop in ChessBoard
        {
           //------------- Dumy test-------------------------------------  
            if (whitepositionY + 2 != blackpositionY - 1&&i<8)
            {
                if (CurrentPlayer.PlayerId == ChessColor.White)
                {
                    whitepositionY = CurrentPlayer.Pieces.ElementAt(i).ChessPiecePosition.Y++;
                    i--;
                }
                else
                    blackpositionY = CurrentPlayer.Pieces.ElementAt(i).ChessPiecePosition.Y--;

            }
            i++;
            if (i==8)
            {
                i = 0;
            }
           //------------------------------------------------------------
            ChangePlayer();

        }
    }
}
