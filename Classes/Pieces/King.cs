using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public class King : Piece
    {
        public King(PlayerColor _color, int _column, int _row)
            : base(_color, _column, _row)
        {

        }
        public King(PlayerColor _color, Coordinate cord)
           : base(_color, cord.Column, cord.Row)
        {

        }
        public override string ViewLeter
        {
            get
            {
                return ResourceClasses.KingLetter;
            }
        }


        public override bool IsPossibleMovement(Coordinate newCoordinates)
        {
            if ((newCoordinates.Column == this.Coordinates.Column + 1) && ((newCoordinates.Row == this.Coordinates.Row + 1) || (newCoordinates.Row == this.Coordinates.Row - 1) || (newCoordinates.Row == this.Coordinates.Row)))
                return true;

            if ((newCoordinates.Column == this.Coordinates.Column - 1) && ((newCoordinates.Row == this.Coordinates.Row + 1) || (newCoordinates.Row == this.Coordinates.Row - 1) || (newCoordinates.Row == this.Coordinates.Row)))
                return true;

            if (newCoordinates.Column == this.Coordinates.Column && (newCoordinates.Row == this.Coordinates.Row + 1 || newCoordinates.Row == this.Coordinates.Row - 1))
                return true;
            
            return false;
        }

    }
}
