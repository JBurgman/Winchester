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

        public void InitializeChessPieceList()
        {
            PlayerList.First().CreateChessPieceList();
        }

        void CalculateNextMove() { }

        void CheckIfThretened() { }

        void MovePiece(Position currentPosition, Position nextPosition) { }
        Player ChangePlayer(Player player) { return player; }
    }
}
