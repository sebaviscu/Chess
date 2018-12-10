using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public class Queen : Piece
    {
        public Queen(PlayerColor _color, int _column, int _row)
            : base(_color, _column, _row)
        {

        }

        public Queen(PlayerColor _color, Coordinate cord)
            : base(_color, cord.Column, cord.Row)
        {

        }


        public override string ViewLeter
        {
            get
            {
                return ResourceClasses.QueenLetter;
            }
        }

        public override bool IsPossibleMovement(Coordinate newCoordinates)
        {
            #region Straight movements
            if (this.Coordinates.Column != newCoordinates.Column && this.Coordinates.Row != newCoordinates.Row)
                if (Math.Abs((this.Coordinates.Row - newCoordinates.Row) / (this.Coordinates.Column - newCoordinates.Column)) == 1)
                    return true;
            #endregion

            #region Diagonal movements
            if ((newCoordinates.Column == this.Coordinates.Column && newCoordinates.Row != this.Coordinates.Row) || (newCoordinates.Row == this.Coordinates.Row && newCoordinates.Column != this.Coordinates.Column))
                return true;
            #endregion
            return false;
        }

        public override bool IsPieceInBetween(Board currectBoard, Coordinate newCoordinates)
        {
            int _row = newCoordinates.Row;
            int _col = newCoordinates.Column;

            #region Straight movements

            if (_col == this.Coordinates.Column)
            {
                _row--;
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
                }
                _row++;
                while (this.Coordinates.Row != _row)
                {
                    if (this.Coordinates.Row >= _row)
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
            #endregion

            #region Diagonal movements

            _row = newCoordinates.Row;
            _col = newCoordinates.Column;

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
            #endregion

            return false;
        }


    }
}
