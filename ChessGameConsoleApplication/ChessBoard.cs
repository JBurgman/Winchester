using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    /// <summary>
    /// This class contains all the UI related attributes and operations
    /// </summary>
    class ChessBoard
    {

        private Tiles tiles ;
       


        
        public Position PositionX { get; set; }
        public Position PositionY { get; set; }
        public int Length { get; private set; }

        
       

        
        



       
        internal void Initialize()
        {
            tiles = new Tiles(new Position(0,0),8,8);
            Start();
        }

        

        internal void Start()
        {

            while (true)
            {

                DrawChessBoard(tiles);
                DrawChessPiece(new PieceSymbol(new Position(0,1),ConsoleColor.White,"B"));
                DrawChessPiece(new PieceSymbol(new Position(4, 7),ConsoleColor.Yellow,"Q"));

                Console.ReadKey();
                Console.Clear();


            }

        }

        private void DrawChessPiece(PieceSymbol pieceSymbol)
        {
            pieceSymbol.Draw();
               
        }

        void DrawChessBoard(ChessBoardLayout chessBoardLayout)
        {
            chessBoardLayout.Draw();
          
        }







    }
}
