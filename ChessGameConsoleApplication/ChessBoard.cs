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

       /// <summary>
       /// This method creates the gameboard and initializes the game
       /// </summary>
        public void Initialize()
        {
            chessGame = new ChessGame();

            chessGame.InitializeChessPieceList();
            tiles = new Tiles(new Position(0,0),8,8);
            Start();
        }

        /// <summary>
        /// This method starts the game and uses the draw-methods to draw everything on the console
        /// </summary>
        public void Start()
        {
            
            while (true)
            {

                DrawChessBoard(tiles);
               
                //---------- This is for testing and will be replaced with real implementaion-------------
                player1=chessGame.PlayerList.First();
                position=player1.Pieces.First().ChessPiecePosition;


                DrawFilesAndRanks(new FilesRanks(ConsoleColor.White));

                DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "P"));
               
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
        /// <summary>
        /// This method is used to draw the chesspieces on the chessboard
        /// </summary>
        /// <param name="pieceSymbol"></param>
        private void DrawChessPiece(PieceSymbol pieceSymbol)
        {
            pieceSymbol.Draw();
               
        }

        /// <summary>
        /// This method is used to draw the chessboard
        /// </summary>
        /// <param name="chessBoardLayout"></param>
        void DrawChessBoard(IChessBoardLayout chessBoardLayout)
        {
            chessBoardLayout.Draw();
          
        }
        /// <summary>
        /// This method is used to draw the files (a-h) and ranks (1-8)
        /// </summary>
        /// <param name="filesRanks"></param>
        void DrawFilesAndRanks(FilesRanks filesRanks)
        {
           filesRanks.Draw();
        }







    }
}
