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

    public class ChessGame : IChessGame, IChessPiece
    {
        //
        //Fields
        Player player1;
        Player player2;

        // Properties
        public List<Player> PlayerList { get; set; }
        public Player CurrentPlayer { get; set; }
        //public Position ChessPiecePosition { get; set; }
        //public int PieceId { get; set; }
        //public PieceType PieceType { get; set; }

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

        public void CalculateNextMove()
        {
            
        }

        public void CheckIfThretened()
        {
            
        }

        public void MovePiece(Position currentPosition, Position nextPosition)
        {
            
        }

        public Player ChangePlayer(Player player)
        {
            return player; 
        }

        public List<Position> GetValidMove()
        {
            return new List<Position>(); //Har den så länge så visual studio inte ska klaga..
        }
    }
}
