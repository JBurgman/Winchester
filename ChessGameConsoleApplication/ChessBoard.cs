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




        
        public Position PositionX { get; set; }
        public Position PositionY { get; set; }
        public int Length { get; private set; }

        
       

        
        private Tiles tiles ;



       
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
                Console.ReadKey();
                Console.Clear();


            }

        }

        void DrawChessBoard(ChessBoardLayout chessBoardLayout)
        {
            chessBoardLayout.Draw();
          
        }







    }
}
