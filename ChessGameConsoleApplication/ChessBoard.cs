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
            // Do initializing stuff

            //Start the game
            Start();
        }

        internal void Start()
        {
            // Start the gameloop
            while (true)
            {
                
                DrawChessboard();
                Console.Read();
                Console.Clear();
                
            }


        
        // Call the Print method
        
        }

        void DrawChessboard()
        {
            Console.WriteLine(this.GetType().Namespace);
        }
    }
}
