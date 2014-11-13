using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    /// <summary>
    /// This class contains the method to draw the files (A-H) and ranks (1-8)
    /// </summary>
    public class FilesRanks : IChessBoardLayout
    {

        public ConsoleColor TextColor { get; set; }

        /// <summary>
        /// Constructor made to tell us what we need when create an object of class "Tiles"
        /// </summary>
        /// <param name="textColor"></param>
        public FilesRanks(ConsoleColor textColor)
        {
            this.TextColor = textColor;
        }
       
        /// <summary>
        /// This method prints out the files (A-H) and the ranks (1-8) around the chessboard
        /// </summary>
        public void Draw()
        { 
            //Files (A-H)
            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("A");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("B");
            Console.SetCursorPosition(2, 9);
            Console.WriteLine("C");
            Console.SetCursorPosition(3, 9);
            Console.WriteLine("D");
            Console.SetCursorPosition(4, 9);
            Console.WriteLine("E");
            Console.SetCursorPosition(5, 9);
            Console.WriteLine("F");
            Console.SetCursorPosition(6, 9);
            Console.WriteLine("G");
            Console.SetCursorPosition(7, 9);
            Console.WriteLine("H");



            //Lines above A-H
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(6, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine("─");
            Console.SetCursorPosition(8, 8);
            Console.WriteLine("┘");


            //Ranks (1-8)
            Console.SetCursorPosition(8, 0);
            Console.WriteLine("8");
            Console.SetCursorPosition(8, 1);
            Console.WriteLine("7");
            Console.SetCursorPosition(8, 2);
            Console.WriteLine("6");
            Console.SetCursorPosition(8, 3);
            Console.WriteLine("5");
            Console.SetCursorPosition(8, 4);
            Console.WriteLine("4");
            Console.SetCursorPosition(8, 5);
            Console.WriteLine("3");
            Console.SetCursorPosition(8, 6);
            Console.WriteLine("2");
            Console.SetCursorPosition(8, 7);
            Console.WriteLine("1");


        }




    }
}
