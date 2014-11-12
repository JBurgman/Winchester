using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    /// <summary>
    /// This class contains the method to draw the files (a-h) and ranks (1-8)
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
        /// This method prints out the files (a-h) and the ranks (1-8) around the chessboard
        /// </summary>
        public void Draw()
        { 
            //Files (a-h)
            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("a");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("b");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("c");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("d");
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("e");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("f");
            Console.SetCursorPosition(6, 8);
            Console.WriteLine("g");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine("h");
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
