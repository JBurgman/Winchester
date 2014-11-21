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
        // Fields
        public ChessGame chessGame;
        private Tiles tiles;
       
        Position position;// Needed?/JE
        
        // Properties
        public Position Position { get; set; }
       
        public int Length { get; private set; }

        /// <summary>
        /// Method that initalize the UI and instantiate the game engine          
        /// </summary>
        public void Initialize()
        {
            chessGame = new ChessGame();//Instantiate the Game Engine, ChessGame

            tiles = new Tiles(new Position(2, 2), 8, 8);//

            Start();//Start the game
        }

        /// <summary>
        /// Method holding the game loop.
        /// </summary>
        public void Start()
        {

            while (true)
            {
                // Draw the chess board and set up the pieces
                DrawChessBoard(tiles);
                DrawFilesAndRanks(new FilesRanks(ConsoleColor.White));
                ChessPiecesSetUp();

                
                DrawLogPost(new PrintLogs(), chessGame.log.LogList); 
                DrawTakenPieces(new TakenPieces(chessGame.CapturedPieces));
                

                //Tell the game engine to move next
                chessGame.CalculateNextMove();//TODO:Change to MoveNext()
                Console.WriteLine();
                Console.ReadKey();//TODO:Time delay insted
                Console.Clear();
            }
        }

        /// <summary>
        /// Method for setting up the chesspieces on the board
        /// </summary>
        private void ChessPiecesSetUp()
        {
            foreach (var player in chessGame.PlayerList)
            {
                foreach (var chesspiece in player.Pieces)
                {
                   
            

                    position = chesspiece.ChessPiecePosition;
                    if (chesspiece.PieceColor == ChessColor.Black)
                    {
                        Console.BackgroundColor = tiles.GetTileColor(position);
                        if (chesspiece.PieceType == PieceType.Pawn)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "P"));
                        }
                        else if (chesspiece.PieceType == PieceType.Rook)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "R"));
                        }
                        else if (chesspiece.PieceType == PieceType.Knight)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "S"));
                        }
                        else if (chesspiece.PieceType == PieceType.Bishop)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "B"));
                        }
                        else if (chesspiece.PieceType == PieceType.Queen)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "Q"));
                        }
                        else if (chesspiece.PieceType == PieceType.King)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "K"));
                        }
                        else if (chesspiece.PieceType == PieceType.Bishop)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "B"));
                        }
                        else if (chesspiece.PieceType == PieceType.Knight)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "S"));
                        }
                        else if (chesspiece.PieceType == PieceType.Rook)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Yellow, "R"));
                        }
                    }
                    if (chesspiece.PieceColor == ChessColor.White)
                    {
                        Console.BackgroundColor = tiles.GetTileColor(position);


                        if (chesspiece.PieceType == PieceType.Pawn)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "P"));
                        }
                        else if (chesspiece.PieceType == PieceType.Rook)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "R"));
                        }
                        else if (chesspiece.PieceType == PieceType.Knight)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "S"));
                        }
                        else if (chesspiece.PieceType == PieceType.Bishop)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "B"));
                        }
                        else if (chesspiece.PieceType == PieceType.Queen)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "Q"));
                        }
                        else if (chesspiece.PieceType == PieceType.King)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "K"));
                        }
                        else if (chesspiece.PieceType == PieceType.Bishop)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "B"));
                        }
                        else if (chesspiece.PieceType == PieceType.Knight)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "S"));
                        }
                        else if (chesspiece.PieceType == PieceType.Rook)
                        {
                            DrawChessPiece(new PieceSymbol(position, ConsoleColor.Cyan, "R"));
                        }
                    }
                }
            }
        }
                

               


        

        void DrawChessPiece(PieceSymbol pieceSymbol)
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


        void DrawTakenPieces(TakenPieces takenPieces)
        {
            
            takenPieces.Draw();
        }

        

        void DrawLogPost(PrintLogs printLog, List<string> logList)
        {
            printLog.Update(logList);
            
            printLog.Draw();
        }

       







    }
}
