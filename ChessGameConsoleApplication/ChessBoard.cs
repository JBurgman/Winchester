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

                DrawChessBoard(tiles);
                DrawFilesAndRanks(new FilesRanks(ConsoleColor.White));
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
                    if (chesspiece.PieceColor==ChessColor.Black)
                    {
                        if(chesspiece.PieceType==PieceType.Pawn)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "P"));
                    }
                    else if (chesspiece.PieceType==PieceType.Rook)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "R"));
                    }
                    else if (chesspiece.PieceType==PieceType.Knight)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "S"));
                    }
                    else if (chesspiece.PieceType==PieceType.Bishop)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "B"));
                    }
                    else if (chesspiece.PieceType==PieceType.Queen)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "Q"));
                    }
                    else if (chesspiece.PieceType==PieceType.King)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "K"));
                    }
                    else if (chesspiece.PieceType==PieceType.Bishop)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "B"));
                    }
                    else if (chesspiece.PieceType==PieceType.Knight)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "S"));
                    }
                    else if (chesspiece.PieceType==PieceType.Rook)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "R"));
                    }
                }
                    if (chesspiece.PieceColor==ChessColor.White)
                    {
                        if (chesspiece.PieceType == PieceType.Pawn)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "P"));
                    }
                        else if (chesspiece.PieceType == PieceType.Rook)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "R"));
                    }
                        else if (chesspiece.PieceType == PieceType.Knight)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "S"));
                    }
                        else if (chesspiece.PieceType == PieceType.Bishop)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "B"));
                    }
                        else if (chesspiece.PieceType == PieceType.Queen)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "Q"));
                    }
                        else if (chesspiece.PieceType == PieceType.King)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "K"));
                    }
                        else if (chesspiece.PieceType == PieceType.Bishop)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "B"));
                    }
                        else if (chesspiece.PieceType == PieceType.Knight)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "S"));
                    }
                        else if (chesspiece.PieceType == PieceType.Rook)
                    {
                        DrawChessPiece(new PieceSymbol(position, ConsoleColor.White, "R"));
                    }
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







    }
}
