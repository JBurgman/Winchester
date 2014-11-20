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
            Console.SetCursorPosition(2, 11);
            Console.WriteLine("A");
            Console.SetCursorPosition(3, 11);
            Console.WriteLine("B");
            Console.SetCursorPosition(4, 11);
            Console.WriteLine("C");
            Console.SetCursorPosition(5, 11);
            Console.WriteLine("D");
            Console.SetCursorPosition(6, 11);
            Console.WriteLine("E");
            Console.SetCursorPosition(7, 11);
            Console.WriteLine("F");
            Console.SetCursorPosition(8, 11);
            Console.WriteLine("G");
            Console.SetCursorPosition(9, 11);
            Console.WriteLine("H");

            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(2, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(3, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(4, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(5, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(6, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(7, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(8, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(9, 10);
            Console.WriteLine("─");
            Console.SetCursorPosition(10, 10);
            Console.WriteLine("┘");
            //Ranks (1-8)
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("│8");
            Console.SetCursorPosition(10, 3);
            Console.WriteLine("│7");
            Console.SetCursorPosition(10, 4);
            Console.WriteLine("│6");
            Console.SetCursorPosition(10, 5);
            Console.WriteLine("│5");
            Console.SetCursorPosition(10, 6);
            Console.WriteLine("│4");
            Console.SetCursorPosition(10, 7);
            Console.WriteLine("│3");
            Console.SetCursorPosition(10, 8);
            Console.WriteLine("│2");
            Console.SetCursorPosition(10, 9);
            Console.WriteLine("│1");

            //Ovanför
            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(2, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(3, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(4, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(5, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(6, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(7, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(8, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(9, 1);
            Console.WriteLine("─");
            Console.SetCursorPosition(10, 1);
            Console.WriteLine("┐");

            Console.SetCursorPosition(1, 1);
            Console.WriteLine("┌");
            Console.SetCursorPosition(1, 2);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 3);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 4);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 5);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 6);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 7);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("│");
            Console.SetCursorPosition(1, 9);
            Console.WriteLine("│");
             Console.SetCursorPosition(1, 10);
             Console.WriteLine("└");
            
        }




    }
}
