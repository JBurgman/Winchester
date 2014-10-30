using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    class Pawn : ChessPiece
    {
        private bool startPosition { get; set; }

        //return?
        public void ValidMove(Position pos)
        {
            //Current Position
            int y = pos.PositionY;
            int x = pos.PositionX;


            //..
        }
    }
}
