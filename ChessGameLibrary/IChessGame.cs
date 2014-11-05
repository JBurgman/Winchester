using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public interface IChessGame
    {
        Player CurrentPlayer { get; set; }
        List<Player> PlayerList { get; set; }

        void CalculateNextMove();
        void CheckIfThretened();
        void MovePiece(Position currentPosition, Position nextPosition);
        Player ChangePlayer(Player player);




    }
}
