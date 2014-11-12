using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;

namespace ChessGameConsoleApplication
{
    class PrintLogs : IChessBoardLayout
    {


        private List<string> logPost = new List<string>();
        


        public PrintLogs(List<string> LogPost)
        {
            this.logPost = LogPost;

        }

        public PrintLogs()
        {
            
        }

        public void Draw()
        {
            string s = "hej";
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(15, 0);
            Console.WriteLine(s);
        }
    }
}
