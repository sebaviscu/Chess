using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    public interface IChessGame
    {
        void Start();

        Coordinate ReadNewCoordinates();

        void ShowsErrorMessage(ErrorOnBoard _error);
    }
}
