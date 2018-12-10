using Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface IBoard
    {

        void DrawBoard();

        void InitialicePieces();

        Piece SearchPieces(int _col, int _row);

        void RemovedPiece(Piece deletePiece);

        void InitialicePiecesRandom();

        void SetCells();

        Coordinate RandomNum(NeedValidationColor valid);

        ErrorOnBoard NewMove(Piece currentPiece, Coordinate newCoordinates);


    }
}
