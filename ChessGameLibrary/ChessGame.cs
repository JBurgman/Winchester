using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class ChessGame
    {
        static void Main(string[] args)
        {
            Random xRandom = new Random();
            ChessBoard c = new ChessBoard();
            c.DisplayBoard();
            Console.ReadKey();

            while (true)
            {
                while (!c.MovePiece(xRandom.Next(0, 8), xRandom.Next(0, 8), xRandom.Next(0, 8), xRandom.Next(0, 8)))
                {

                }
                c.DisplayBoard();
                Console.WriteLine("Pieces: " + c.CountPieces());
                Console.ReadKey();
            }
        }
    }
}
