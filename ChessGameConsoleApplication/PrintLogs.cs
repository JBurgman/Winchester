using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;

namespace ChessGameConsoleApplication
{
    class PrintLogs : IChessBoardLayout
    {


        private List<string> logPost;

        

        public PrintLogs(List<string> LogPost)
        {
            this.logPost = LogPost;

        }

        public PrintLogs()
        {
            
        }

        public void Draw()    // Not sure about this. Can not check if it is working. 
        {


                logPost.Add("1. Move");
                logPost.Add("2.move");

            foreach (var adds in logPost)
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine(adds);
                }
            }
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(15, 0);
                Console.WriteLine();
           
        }
    }
}
