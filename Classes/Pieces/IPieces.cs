using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.Pieces
{
    public interface IPieces
    {
        bool IsPossibleMovement(Coordinate newCoordinates);

        bool IsPieceInBetween(Board currectBoard, Coordinate newCoordinates);


    }
}
