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
    public class Player
    {
        // Fields
        private readonly ChessPieceFactory chessPieceFactory;
        ////private IChessPiece chessPiece;

        //Properties
        public List<IChessPiece> Pieces { get; set; }

        public ChessColor PlayerId { get; set; }

        public Player(ChessColor playerId)
        {
            Pieces = new List<IChessPiece>();
            chessPieceFactory = new ChessPieceFactory(Pieces);

            this.PlayerId = playerId;
        }

        public void CreateChessPieceList() 
        {
            Pieces=chessPieceFactory.CreateChessPiece(PlayerId);
           
        }

       

    }
}
