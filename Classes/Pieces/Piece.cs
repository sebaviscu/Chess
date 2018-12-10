using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public abstract class Piece : IPieces
    {
        public Piece(PlayerColor _color, int _column, int _row)
        {
            Coordinates = new Coordinate(_column, _row);
            Color = _color;
        }

        /// <summary>
        /// Color of the piece that differentiates the players
        /// </summary>
        public PlayerColor Color { get; set; }
        /// <summary>
        /// Letter with which the piece is represented on the board
        /// </summary>
        public virtual string ViewLeter
        {
            get;
            set;
        }
        /// <summary>
        /// Return if it is possible to make the move
        /// </summary>
        /// <param name="newCoordinates">Destination coordinates</param>
        /// <returns></returns>
        public virtual bool IsPossibleMovement(Coordinate newCoordinates)
        {
            return true;
        }
        /// <summary>
        /// Return if there are interposed pieces
        /// </summary>
        /// <param name="currectBoard">Board where the movement is made</param>
        /// <param name="newCoordinates">Destination coordinates</param>
        /// <returns></returns>
        public virtual bool IsPieceInBetween(Board currectBoard, Coordinate newCoordinates)
        {
            return false;
        }
        /// <summary>
        /// Current coordinates of the piece
        /// </summary>
        public Coordinate Coordinates { get; set; }

    }
    /// <summary>
    /// Possible colors of the pieces
    /// </summary>
    public enum PlayerColor
    {
        Black, White
    }

}
