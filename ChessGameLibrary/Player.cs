using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    /// <summary>
    /// The player class holds a list of ChessPieces
    /// </summary>
    class Player
    {
        // Fields
        

        //Properties
        List<ChessPiece> Pieces { get; set; }

        int PlayerId { get; private set; }

       

    }
}
