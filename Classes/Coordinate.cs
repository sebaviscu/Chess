using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Coordinate
    {

        public Coordinate(int _col, int _row)
        {
            this.Column = _col;
            this.Row = _row;
        }

        public int Row { get; set; }

        public int Column { get; set; }


    }
}
