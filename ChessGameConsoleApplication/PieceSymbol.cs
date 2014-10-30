using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    class PieceSymbol : ChessBoardLayout
    {

        public ConsoleColor PieceColor { get; set; }
        public string Symbol { get; set; }

        public override void Draw()
        {
            //Implement logic to draw
        }
    }
}
