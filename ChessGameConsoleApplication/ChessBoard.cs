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
        private Tiles tiles;
        //Player player1;
        //Player player2;
        Position position;



        public Position Position { get; set; }

        public int Length { get; private set; }


        public void Initialize()
        {
            chessGame = new ChessGame();

            chessGame.InitializeChessPieceList();
            tiles = new Tiles(new Position(0, 0), 8, 8);
            Start();
        }



        public void Start()
        {

            while (true)
            {

                DrawTakenPieces(new TakenPieces(), new List<IChessPiece>());
                DrawLogPost(new PrintLogs(), chessGame.LogPost);
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
                    position = chesspiece.ChessPiecePosition;

                    Console.BackgroundColor = tiles.GetTileColor(position);

                    if (chesspiece.PieceId <= 8)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "P"));
                    }
                    else 
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Red, "P"));
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

        void DrawLogPost(PrintLogs printLog, List<string> printLogs)
        {
            this.chessGame.LogPost = printLogs;
            printLog.Draw();
        }

        void DrawTakenPieces(TakenPieces takenPiece, List<IChessPiece> takenPieces)
        {
            this.chessGame.TakenPieces = takenPieces;
            takenPiece.Draw();
        }

      





    }
}
