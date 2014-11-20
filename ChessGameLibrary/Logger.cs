using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public class Logger
    {
        public List<string> LogList;

        public void Log(Player currentPlayer, IChessPiece piece, Position currentPos, Position nextPos)
        {
           
            //Player
            string player;

            if (currentPlayer.PlayerId == ChessColor.White)
                player = "White";
            else
                player = "Black";

            //Convert X-positions to letters
            string letters = "ABCDEFGH";
 
            string currentX = char.ToString(letters[currentPos.X]);
            string nextX = char.ToString(letters[nextPos.X]);

            //Change Y-positions to correct number
            string numbers = "87654321";

            string currentY = char.ToString(numbers[currentPos.Y]);
            string nextY = char.ToString(numbers[nextPos.Y]);

            //Add move to log
            //LogList.Add(player + " moved " + piece.PieceType + " from " + currentX + currentY + " to " + nextX + nextY);
            if (piece.PieceType == PieceType.Pawn)
            {
           
                LogList.Add(player + " moved: " + piece.ToString() + " from " + currentX + currentY + " to " + nextX +
                            nextY);
            }
            else
            {
                
                LogList.Add(player + " moved: " + piece.ToString() + " from " + currentX + currentY + " to " + nextX +
                            nextY);
            }
        }


        public Logger()
        {
            LogList = new List<string>();
            LogList.Add(" ");
            LogList.Add(" ");
            LogList.Add(" ");
            LogList.Add(" ");
            LogList.Add(" ");
            LogList.Add(" ");
            LogList.Add(" ");
            LogList.Add(" ");
        }
    }
}
