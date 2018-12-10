using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public class Horse : Piece
    {
        public Horse(PlayerColor _color, int _column, int _row)
            : base(_color, _column, _row)
        {

        }

        public Horse(PlayerColor _color, Coordinate cord)
           : base(_color, cord.Column, cord.Row)
        {

        }

        public override string ViewLeter
        {
            get
            {
                return ResourceClasses.HorseLetter;
            }
        }

        public override bool IsPossibleMovement(Coordinate newCoordinates)
        {

            if ((this.Coordinates.Row + 2 == newCoordinates.Row) && (this.Coordinates.Column + 1 == newCoordinates.Column || (this.Coordinates.Column - 1 == newCoordinates.Column)))
                return true;

            if ((this.Coordinates.Row - 2 == newCoordinates.Row) && (this.Coordinates.Column + 1 == newCoordinates.Column || (this.Coordinates.Column - 1 == newCoordinates.Column)))
                return true;

            if ((this.Coordinates.Column + 2 == newCoordinates.Column) && (this.Coordinates.Row + 1 == newCoordinates.Row || (this.Coordinates.Row - 1 == newCoordinates.Row)))
                return true;

            if ((this.Coordinates.Column - 2 == newCoordinates.Column) && (this.Coordinates.Row + 1 == newCoordinates.Row || (this.Coordinates.Row - 1 == newCoordinates.Row)))
                return true;

            return false;
        }


    }
}
