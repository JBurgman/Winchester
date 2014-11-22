﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;

namespace ChessGameConsoleApplication
{
    class TakenPieces : IChessBoardLayout
    {
       
        private List<IChessPiece> capturedPieces;

        public TakenPieces(List<IChessPiece> capturedPieces)
        {
            this.capturedPieces = capturedPieces;
        }
        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(0,15);
            Console.WriteLine("Captured pieces: ");
           


            foreach (IChessPiece piece in capturedPieces)
            {
                if (piece.PieceColor==ChessColor.White)
                {
                     Console.ForegroundColor = ConsoleColor.Cyan;
                     Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                { 
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
            }
                Console.Write(piece);
            }
            Console.SetCursorPosition(0, 18);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Black;
           
        }
    }
}
