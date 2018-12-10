using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public class Pawn : Piece
    {
        public Pawn(PlayerColor _color, int _column, int _row)
            : base(_color, _column, _row)
        {
            IsFirstStep = true;
        }

        public Pawn(PlayerColor _color, Coordinate cord)
            : base(_color, cord.Column, cord.Row)
        {

        }

        public override string ViewLeter
        {
            get
            {
                return ResourceClasses.PawnLetter;
            }
        }

        public override bool IsPossibleMovement(Coordinate newCoordinates)
        {
            int step = 1;

            if (IsFirstStep)
            {
                step++;
                IsFirstStep = false;
            }

            if (newCoordinates.Column == this.Coordinates.Column && (newCoordinates.Row - this.Coordinates.Row) <= step)
                return true;

            return false;

        }

        public bool IsFirstStep { get; set; }

    }
}
