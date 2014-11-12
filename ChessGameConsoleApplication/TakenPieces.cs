using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;

namespace ChessGameConsoleApplication
{
    class TakenPieces: IChessBoardLayout
    {
       
        private List<IChessPiece> takenPieces = new List<IChessPiece>();

        public TakenPieces()
        {
            
        }



        public void Draw()
        {
            string s = "haaaaaaaaalååååååååååååååååååååååååå";
            Console.SetCursorPosition(0,10);
            Console.WriteLine(s);
            
            foreach (IChessPiece piece in takenPieces)
            {
                Console.SetCursorPosition(0, 10);
                Console.WriteLine(piece);
            }
        }

        
    }
}
