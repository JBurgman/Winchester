using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    class PieceSymbol : ChessBoardLayout
    {
        public Position Position { get; set; }
        public ConsoleColor PieceColor { get; set; }
        public string Symbol { get; set; }

        public PieceSymbol(Position position, ConsoleColor pieceColor, string symbol)
        { 
            this.Position = position;
            this.PieceColor = pieceColor;
            this.Symbol = symbol;
        }

        public override void Draw()
        {
            //Implement logic to draw
            try
            {




                    Console.ForegroundColor = PieceColor;
                    Console.SetCursorPosition(Position.X , Position.Y);
                    Console.Write(Symbol);

                


            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }

        }
    }
}
