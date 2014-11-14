﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;

namespace ChessGameConsoleApplication
{
    class PrintLogs : IChessBoardLayout
    {


        private List<string> logPost {get; set; }



        public PrintLogs(List<string> LogPost)
        {
            this.logPost = LogPost;

        }

        public PrintLogs()
        {

        }

        public void Update(List<string> logList)
        {
            this.logPost = logList;
        }

        /// <summary>
        /// This method prints out the 5 latest moves.
        /// </summary>
        public void Draw()
        {

            Console.SetCursorPosition(15, 0);


                for (int y = 1; y < 6; y++)
                {
                    Console.SetCursorPosition(15, y);
                    Console.WriteLine(logPost[(logPost.Count - y)]);
                }
            
        }
    }
}