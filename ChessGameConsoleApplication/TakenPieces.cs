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
            //string s = "P, K, B, P, P, B, R";
            //Console.SetCursorPosition(0,12);
            //Console.WriteLine(s);

            Console.SetCursorPosition(0,11);
            Console.WriteLine("Captured pieces: ");
            Console.SetCursorPosition(0, 12);


            foreach (IChessPiece piece in capturedPieces)
            {
                if (piece.PieceColor==ChessColor.White)
                {
                     Console.ForegroundColor = ConsoleColor.White;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Yellow;
            
                Console.Write(piece);
            }
        }

        
    }
}
