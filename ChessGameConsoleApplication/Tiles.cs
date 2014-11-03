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

            for (int i = 0; i < this.Width; i++)
            {

                for (int j = 0; j < this.Height; j++)
                {
                    if (((i % 2 == 0) && (j % 2 == 0)) || ((i % 2 == 1) && (j % 2 == 1))) // Om bägge koordinaterna är udda eller bägge koordinaterna är jämna
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }


                    Console.SetCursorPosition(StartPosition.X + i, StartPosition.Y + j);


                    Console.Write("█");
                }
                Console.WriteLine();
            }
        }
    }
}
