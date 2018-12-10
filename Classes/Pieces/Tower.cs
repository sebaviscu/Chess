using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public class Tower : Piece
    {
        public Tower(PlayerColor _color, int _column, int _row)
            : base(_color, _column, _row)
        {

        }

        public Tower(PlayerColor _color, Coordinate cord)
            : base(_color, cord.Column, cord.Row)
        {

        }

        public override string ViewLeter
        {
            get
            {
                return ResourceClasses.TowerLetter;
            }
        }

        public override bool IsPossibleMovement(Coordinate newCoordinates)
        {

            if ((newCoordinates.Column == this.Coordinates.Column && newCoordinates.Row != this.Coordinates.Row) || (newCoordinates.Row == this.Coordinates.Row && newCoordinates.Column != this.Coordinates.Column))
                return true;

            return false;
        }

        public override bool IsPieceInBetween(Board currectBoard, Coordinate newCoordinates)
        {
            int _row = newCoordinates.Row;
            int _col = newCoordinates.Column;

            if (_col == this.Coordinates.Column)
            {
                while (this.Coordinates.Row != _row)
                {
                    if (this.Coordinates.Row <= _row)
                    {
                        if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                        {
                            return true;
                        }
                        _row--;
                    }
                    else
                    {
                        if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                        {
                            return true;
                        }
                        _row++;
                    }
                }
            }
            else if (_row == this.Coordinates.Row)
            {
                while (this.Coordinates.Column != _col)
                {
                    if (this.Coordinates.Column <= _col)
                    {
                        if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                        {
                            return true;
                        }
                        _col--;
                    }
                    else
                    {
                        if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                        {
                            return true;
                        }
                        _col++;
                    }
                }
            }
            return false;
        }


    }
}
