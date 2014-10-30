using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    abstract class ChessBoardLayout
    {
        protected int Position { get; set; }

        public virtual void Draw()
        {
            
            //Implement logic to draw

        }
    }
}
