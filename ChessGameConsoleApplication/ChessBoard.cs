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


                DrawFilesAndRanks(new FilesRanks(ConsoleColor.White));

                //Trying to see how it will look like
                DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "P"));  // This pawn is the only one who can move, right now. 


                // White side, unmoveable pieces.

                DrawChessPiece(new PieceSymbol(new Position(1,1), ConsoleColor.White, "P"));
                DrawChessPiece(new PieceSymbol(new Position(2,1), ConsoleColor.White, "P")); 
                DrawChessPiece(new PieceSymbol(new Position(3,1), ConsoleColor.White, "P"));
                DrawChessPiece(new PieceSymbol(new Position(4,1), ConsoleColor.White, "P"));
                DrawChessPiece(new PieceSymbol(new Position(5,1), ConsoleColor.White, "P"));
                DrawChessPiece(new PieceSymbol(new Position(6,1), ConsoleColor.White, "P"));
                DrawChessPiece(new PieceSymbol(new Position(7,1), ConsoleColor.White, "P"));

                DrawChessPiece(new PieceSymbol(new Position(7, 0), ConsoleColor.White, "R"));
                DrawChessPiece(new PieceSymbol(new Position(6, 0), ConsoleColor.White, "H"));
                DrawChessPiece(new PieceSymbol(new Position(5, 0), ConsoleColor.White, "B"));
                DrawChessPiece(new PieceSymbol(new Position(4, 0), ConsoleColor.White, "K"));
                DrawChessPiece(new PieceSymbol(new Position(3, 0), ConsoleColor.White, "Q"));
                DrawChessPiece(new PieceSymbol(new Position(2, 0), ConsoleColor.White, "B"));
                DrawChessPiece(new PieceSymbol(new Position(1, 0), ConsoleColor.White, "H"));
                DrawChessPiece(new PieceSymbol(new Position(0, 0), ConsoleColor.White, "R"));



                //RED (black) Side. Unmoveable pieces.. 


                DrawChessPiece(new PieceSymbol(new Position(0, 6), ConsoleColor.Red, "P"));
                DrawChessPiece(new PieceSymbol(new Position(1, 6), ConsoleColor.Red, "P")); 
                DrawChessPiece(new PieceSymbol(new Position(2, 6), ConsoleColor.Red, "P"));
                DrawChessPiece(new PieceSymbol(new Position(3, 6), ConsoleColor.Red, "P"));
                DrawChessPiece(new PieceSymbol(new Position(4, 6), ConsoleColor.Red, "P"));
                DrawChessPiece(new PieceSymbol(new Position(5, 6), ConsoleColor.Red, "P"));
                DrawChessPiece(new PieceSymbol(new Position(6, 6), ConsoleColor.Red, "P"));
                DrawChessPiece(new PieceSymbol(new Position(7, 6), ConsoleColor.Red, "P"));

               
                DrawChessPiece(new PieceSymbol(new Position(7, 7), ConsoleColor.Red, "R"));
                DrawChessPiece(new PieceSymbol(new Position(6, 7), ConsoleColor.Red, "H"));
                DrawChessPiece(new PieceSymbol(new Position(5, 7), ConsoleColor.Red, "B"));
                DrawChessPiece(new PieceSymbol(new Position(4, 7), ConsoleColor.Red, "Q"));
                DrawChessPiece(new PieceSymbol(new Position(3, 7), ConsoleColor.Red, "K"));
                DrawChessPiece(new PieceSymbol(new Position(2, 7), ConsoleColor.Red, "B"));
                DrawChessPiece(new PieceSymbol(new Position(1, 7), ConsoleColor.Red, "H"));
                DrawChessPiece(new PieceSymbol(new Position(0, 7), ConsoleColor.Red, "R"));



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

        void DrawFilesAndRanks(FilesRanks filesRanks)
        {
           filesRanks.Draw();
        }







    }
}
