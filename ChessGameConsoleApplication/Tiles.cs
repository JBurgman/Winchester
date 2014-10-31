using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    internal class Tiles : ChessBoardLayout
    {

        public Position StartPosition { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Tiles(Position startPosition, int width, int height)
        {
            StartPosition = startPosition;
            this.Width = width;
            this.Height = height;
        }
        public override void Draw()
        {

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.SetCursorPosition(StartPosition.X + x, StartPosition.Y + y);
                    Console.WriteLine("#");
                }
             
                
            }
        }
    }
}
