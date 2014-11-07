using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    public class FilesRanks : IChessBoardLayout
    {

        public ConsoleColor TextColor { get; set; }
        public FilesRanks(ConsoleColor textColor)
        {
            this.TextColor = textColor;
        }
       
        public void Draw()
        {

            //Files (a-h)
            Console.ForegroundColor = TextColor;
            Console.SetCursorPosition(0, 8);
            Console.WriteLine("A");
            Console.SetCursorPosition(1, 8);
            Console.WriteLine("B");
            Console.SetCursorPosition(2, 8);
            Console.WriteLine("C");
            Console.SetCursorPosition(3, 8);
            Console.WriteLine("D");
            Console.SetCursorPosition(4, 8);
            Console.WriteLine("E");
            Console.SetCursorPosition(5, 8);
            Console.WriteLine("F");
            Console.SetCursorPosition(6, 8);
            Console.WriteLine("G");
            Console.SetCursorPosition(7, 8);
            Console.WriteLine("H");
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
