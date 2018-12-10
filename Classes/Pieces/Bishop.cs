using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public class Bishop : Piece
    {
        public Bishop(PlayerColor _color, int _column, int _row)
            : base(_color, _column, _row)
        {

        }
        public Bishop(PlayerColor _color, Coordinate cord)
            : base(_color, cord.Column, cord.Row)
        {

        }

        public override string ViewLeter
        {
            get
            {
                return ResourceClasses.BishopLetter;
            }
        }

        public override bool IsPossibleMovement(Coordinate newCoordinates)
        {
            if (Math.Abs((this.Coordinates.Row - newCoordinates.Row) / (this.Coordinates.Column - newCoordinates.Column)) == 1)
                return true;

            return false;
        }


        public override bool IsPieceInBetween(Board currectBoard, Coordinate newCoordinates)
        {
            int _row = newCoordinates.Row;
            int _col = newCoordinates.Column;

            if (this.Coordinates.Column < _col && this.Coordinates.Row < _row) // caso 4
            {
                _col--;
                _row--;
                while (this.Coordinates.Column < _col && this.Coordinates.Row < _row)
                {
                    if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                    {
                        return true;
                    }
                    _col--;
                    _row--;
                }
            }

            if (this.Coordinates.Column < _col && this.Coordinates.Row > _row) // caso 3
            {
                _col--;
                _row++;
                while (this.Coordinates.Column < _col && this.Coordinates.Row > _row)
                {

                    if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                    {
                        return true;
                    }
                    _col--;
                    _row++;
                }
            }

            if (this.Coordinates.Column > _col && this.Coordinates.Row > _row) // caso 1
            {
                _col++;
                _row++;
                while (this.Coordinates.Column > _col && this.Coordinates.Row > _row)
                {
                    if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                    {
                        return true;
                    }
                    _col++;
                    _row++;
                }
            }

            if (this.Coordinates.Column > _col && this.Coordinates.Row < _row) // caso 2
            {
                _col++;
                _row--;
                while (this.Coordinates.Column > _col && this.Coordinates.Row < _row)
                {
                    if (currectBoard.Pieces.Any(x => x.Coordinates.Column == _col && x.Coordinates.Row == _row))
                    {
                        return true;
                    }
                    _col++;
                    _row--;
                }
            }

            return false;
        }



    }
}
