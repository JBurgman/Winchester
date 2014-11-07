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
        //Player player1;
        //Player player2;
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
                ChessPiecesSetUp();
                chessGame.NextMove();
                
               
                Console.ReadKey();
                Console.Clear();


            }

        }

        private void ChessPiecesSetUp()
        {
            foreach (var player in chessGame.PlayerList)
            {
                foreach (var chesspiece in player.Pieces)
                {
                    position = chesspiece.ChessPiecePosition;
                    if (chesspiece.PieceId<=8)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "P"));
                    }
                    else
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "P"));
                    }
                    
                }
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
