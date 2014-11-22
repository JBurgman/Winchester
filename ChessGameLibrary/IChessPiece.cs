using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessGameLibrary
{
    public interface IChessPiece
    {
        Position ChessPiecePosition { get; set; }
        int PieceId { get; set; }
        bool StartPosition { get; set; }
        PieceType PieceType { get; set; }
        bool StartPosition { get; set; }
        ChessColor PieceColor { get; set; }

        List<Position> GetValidMove(Player CurrentPlayer, Player Opponent);

    }
}
