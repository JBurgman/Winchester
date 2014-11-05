using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;


namespace ChessGameConsoleApplication
{
    /// <summary>
    /// This class contains all the UI related attributes and operations
    /// </summary>
    public class ChessBoard
    {
        public ChessGame chessGame;
        private Tiles tiles ;
        Player player1;
        Player player2;
        Position position;


        
        public Position Position { get; set; }
       
        public int Length { get; private set; }

       
        public void Initialize()
        {
            chessGame = new ChessGame();

            chessGame.InitializeChessPieceList();
            tiles = new Tiles(new Position(0,0),8,8);
            Start();
        }

        

        public void Start()
        {

            while (true)
            {

                DrawChessBoard(tiles);
               
                //---------- This is for testing and will be replaced with real implementaion-------------
                player1=chessGame.PlayerList.First();
                position=player1.Pieces.First().ChessPiecePosition;

                DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "B"));
               
                DrawChessPiece(new PieceSymbol(new Position(4, 7),ConsoleColor.Yellow,"Q"));

                if (position.Y<7)
                {
                    position.Y++;
                }
                
                //-----------------------------------------------------------------------------------------
                Console.ReadKey();
                Console.Clear();


            }

        }

        private void DrawChessPiece(PieceSymbol pieceSymbol)
        {
            pieceSymbol.Draw();
               
        }

        void DrawChessBoard(IChessBoardLayout chessBoardLayout)
        {
            chessBoardLayout.Draw();
          
        }







    }
}
