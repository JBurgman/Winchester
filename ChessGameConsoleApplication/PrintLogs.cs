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

            logPost.Add("hej");
            logPost.Add("qweqwe");
            logPost.Add("qwewqe");
            logPost.Add("qqweqwe");
            logPost.Add("qweqsd");
            logPost.Add("asdasd");
            logPost.Add("hejhalå");
            Console.SetCursorPosition(15, 0);


            for (int y = 1; y < 6; y++)
            {
                Console.SetCursorPosition(15, y);
                Console.WriteLine(logPost[(logPost.Count - y)]);
            }
           
        }
    }
}
