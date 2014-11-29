﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
﻿using System.Security.Cryptography.X509Certificates;
﻿using System.Text;
using System.Threading.Tasks;
using ChessGameLibrary;

namespace ChessGameConsoleApplication
{
    internal class PrintLogs : IChessBoardLayout

    {
        private List<string> logPost { get; set; }

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
            for (int y = 1; y < 6; y++)
            {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(20, y);
                    Console.WriteLine(logPost[(logPost.Count - y)]);
            }
        }
    }
}