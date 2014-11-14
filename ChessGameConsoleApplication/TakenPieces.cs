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

        private List<IChessPiece> takenPieces = new List<IChessPiece>();


        public void Draw()
        {
            Console.ForegroundColor = ConsoleColor.White;
            string s = "P, K, B, P, P, B, R";
            Console.SetCursorPosition(0, 12);
            Console.WriteLine(s);

            Console.SetCursorPosition(0, 11);
            Console.WriteLine("Captured pieces: ");



            foreach (IChessPiece piece in takenPieces)
            {
                Console.SetCursorPosition(0, 10);
                Console.WriteLine(piece);
            }
        }


    }
}