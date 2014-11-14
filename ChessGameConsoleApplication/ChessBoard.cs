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
                DrawTakenPieces(new TakenPieces(), new List<IChessPiece>());

                DrawLogPost(new PrintLogs(), chessGame.log.LogList);

                DrawFilesAndRanks(new FilesRanks(ConsoleColor.White));

                DrawChessBoard(tiles);
                ChessPiecesSetUp();
                chessGame.CalculateNextMove();

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
                    ConsoleColor Color;

                    if (player.PlayerId == ChessColor.Black)
                    {
                        Color = ConsoleColor.Yellow;
                    }
                    else
                    {
                        Color = ConsoleColor.White;
                    }
                        

                    position = chesspiece.ChessPiecePosition;

                    if (chesspiece.PieceId <= 8)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "P"));
                    }
                    else if (chesspiece.PieceId == 9)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "R"));
                    }
                    else if (chesspiece.PieceId == 10)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "S"));
                    }
                    else if (chesspiece.PieceId == 11)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "B"));
                    }
                    else if (chesspiece.PieceId == 12)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "Q"));
                    }
                    else if (chesspiece.PieceId == 13)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "K"));
                    }
                    else if (chesspiece.PieceId == 14)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "B"));
                    }
                    else if (chesspiece.PieceId == 15)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "S"));
                    }
                    else if (chesspiece.PieceId == 16)
                    {
                        DrawChessPiece(new PieceSymbol(position, Color, "R"));
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

        void DrawLogPost(PrintLogs printLog, List<string> logList)
        {
            printLog.Update(logList);
            
            printLog.Draw();
        }

        void DrawTakenPieces(TakenPieces takenPiece, List<IChessPiece> takenPieces)
        {
            this.chessGame.TakenPieces = takenPieces;
            takenPiece.Draw();
        }








    }
}
