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
        public Position ChessPiecePosition { get; set; }
        public int PieceId { get; set; }
        public PieceType PieceType { get; set; }
        /// <summary>
        /// This method creates a playerlist where two players, each one of them assigned with a unique color, are added.
        /// </summary>
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
        /// This method creates a chesspiece list for one of the players.
        /// </summary>
        public void InitializeChessPieceList()
        {
            PlayerList.First().CreateChessPieceList();
        }

        /// <summary>
        /// This method calculates the next move to make
        /// </summary>
        public void CalculateNextMove()
        {
            
        }

        /// <summary>
        /// This method checks if a chesspiece is threatend
        /// </summary>
        public void CheckIfThretened()
        {
            
        }

        /// <summary>
        /// This method is used to move a chesspiece.
        /// </summary>
        /// <param name="currentPosition"></param>
        /// <param name="nextPosition"></param>
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
