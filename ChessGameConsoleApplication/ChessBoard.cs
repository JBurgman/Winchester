using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameConsoleApplication
{
    /// <summary>
    /// This class contains all the UI related attributes and operations
    /// </summary>
    class ChessBoard
    {
        // Fields

        // Properties

        // Constuctors
        public ChessBoard() { }

        // Methods

        /// <summary>
        /// Start the gameloop and initialize the chessboard
        /// </summary>
        internal void Initialize()
        {
            // Call the Print method
            Print();
        }

        void Print()
        {
            Console.WriteLine(this.GetType().Namespace);
        }
    }
}
