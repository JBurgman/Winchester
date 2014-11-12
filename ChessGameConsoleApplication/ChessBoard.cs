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
        public List<string> LogPost;  


       
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
                DrawFilesAndRanks(new FilesRanks(ConsoleColor.White));
                ChessPiecesSetUp();
                chessGame.CalculateNextMove();
                Console.ReadKey();
                Console.Clear();
               

                DrawTakenPieces(new TakenPieces(), new List<IChessPiece>());

        }

        private void ChessPiecesSetUp()
        {
            foreach (var player in chessGame.PlayerList)
            {
                foreach (var chesspiece in player.Pieces)
                {
                    position = chesspiece.ChessPiecePosition;
                    if (chesspiece.PieceId <= 8)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "P"));
                    }
                    else if (chesspiece.PieceId ==9)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "R"));
                    }
                    else if (chesspiece.PieceId == 10)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "S"));
                    }
                    else if (chesspiece.PieceId == 11)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "B"));
                    }
                    else if (chesspiece.PieceId == 12)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "Q"));
                    }
                    else if (chesspiece.PieceId == 13)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "K"));
                    }
                    else if (chesspiece.PieceId == 14)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "B"));
                    }
                    else if (chesspiece.PieceId == 15)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "S"));
                    }
                    else if (chesspiece.PieceId == 16)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "R"));
                    }
                    else if (chesspiece.PieceId > 16 && chesspiece.PieceId<25)
                    {
                DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "P"));
                    }
                    else if (chesspiece.PieceId == 25)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "R"));
                    }
                    else if (chesspiece.PieceId == 26)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "S"));
                    }
                    else if (chesspiece.PieceId == 27)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "B"));
                    }
                    else if (chesspiece.PieceId == 28)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "Q"));
                    }
                    else if (chesspiece.PieceId == 29)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "K"));
                    }
                    else if (chesspiece.PieceId == 30)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "B"));
                    }
                    else if (chesspiece.PieceId == 31)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "S"));
                    }
                    else if (chesspiece.PieceId == 32)
                {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "R"));
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

        void DrawFilesAndRanks(FilesRanks filesRanks)
        {
           filesRanks.Draw();
        }


        void DrawTakenPieces(TakenPieces takenPiece, List<IChessPiece> takenPieces)
        {
            this.chessGame.TakenPieces = takenPieces;
            takenPiece.Draw();
        }








    }
}
