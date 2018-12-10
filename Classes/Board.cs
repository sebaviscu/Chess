using Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Board : IBoard
    {
        private List<Piece> l_pieces = new List<Piece>();
        private List<Coordinate> l_coord = new List<Coordinate>();

        /// <summary>
        /// List of pieces on the board
        /// </summary>
        public List<Piece> Pieces
        {
            get { return l_pieces; }
            set { l_pieces = value; }
        }

        /// <summary>
        /// List of possible coordinates
        /// </summary>
        public List<Coordinate> Coordinates
        {
            get { return l_coord; }
            set { l_coord = value; }
        }

        /// <summary>
        /// Draw the board
        /// </summary>
        public void DrawBoard()
        {
            Console.WriteLine();

            for (int row = 1; row <= 8; row++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(string.Format(" {0}  ", row.ToString()));

                for (int column = 1; column <= 8; column++)
                {
                    if ((row + column) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.Gray;// blanco
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;// negro

                    var piecesSearch = SearchPieces(column, row);
                    if (piecesSearch != null)
                    {
                        if (piecesSearch.Color == PlayerColor.Black)
                            Console.ForegroundColor = ConsoleColor.Black;
                        else
                            Console.ForegroundColor = ConsoleColor.White;

                        Console.Write(string.Format(" {0} ", piecesSearch.ViewLeter));
                    }
                    else
                    {
                        if ((row + column) % 2 == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" _ "); // blanco
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.Write(" _ "); // negro
                        }
                    }
                }
                Console.WriteLine(); // cambiar de fila
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine();
            Console.WriteLine("     a  b  c  d  e  f  g  h");
            Console.WriteLine();

        }

        /// <summary>
        /// Create the pieces of the board
        /// </summary>
        public void InitialicePieces()
        {
            for (int i = 1; i <= 8; i++)
            {
                Pieces.Add(new Tower(PlayerColor.Black, 1, i));
                Pieces.Add(new Horse(PlayerColor.Black, 2, i));
                Pieces.Add(new Bishop(PlayerColor.Black, 3, i));
                Pieces.Add(new King(PlayerColor.Black, 4, i));
                Pieces.Add(new Queen(PlayerColor.Black, 5, i));
                Pieces.Add(new Bishop(PlayerColor.Black, 6, i));
                Pieces.Add(new Horse(PlayerColor.Black, 7, i));
                Pieces.Add(new Tower(PlayerColor.Black, 8, i));
                i += 6;
            }

            for (int i = 1; i <= 8; i++)
            {
                Pieces.Add(new Pawn(PlayerColor.Black, i, 2));
                Pieces.Add(new Pawn(PlayerColor.White, i, 7));
            }

        }
        
        /// <summary>
        /// Returns a piece of the board
        /// </summary>
        /// <param name="_col">Column of the coordinate</param>
        /// <param name="_row">Row of the coordinate</param>
        /// <returns></returns>
        public Piece SearchPieces(int _col, int _row)
        {
            Classes.Pieces.Piece currentPrice = Pieces.FirstOrDefault(x => x.Coordinates.Row == _row && x.Coordinates.Column == _col);
            return currentPrice;
        }

        /// <summary>
        /// Remove one piece from the board
        /// </summary>
        /// <param name="deletePiece"></param>
        public void RemovedPiece(Piece deletePiece)
        {
            Pieces.Remove(deletePiece);
        }

        /// <summary>
        /// Create the pieces of the board in a random way
        /// </summary>
        public void InitialicePiecesRandom()
        {
            SetCells();
            var colorPlayer = PlayerColor.Black;

            for (int i = 0; i < 2; i++)
            {
                Pieces.Add(new Tower(colorPlayer, RandomNum(NeedValidationColor.None)));
                Pieces.Add(new Horse(colorPlayer, RandomNum(NeedValidationColor.None)));
                Pieces.Add(new Bishop(colorPlayer, RandomNum(NeedValidationColor.White)));
                Pieces.Add(new King(colorPlayer, RandomNum(NeedValidationColor.None)));
                Pieces.Add(new Queen(colorPlayer, RandomNum(NeedValidationColor.None)));
                Pieces.Add(new Bishop(colorPlayer, RandomNum(NeedValidationColor.Black)));
                Pieces.Add(new Horse(colorPlayer, RandomNum(NeedValidationColor.None)));
                Pieces.Add(new Tower(colorPlayer, RandomNum(NeedValidationColor.None)));

                colorPlayer = PlayerColor.White;
            }

            for (int i = 1; i <= 8; i++)
            {
                Pieces.Add(new Pawn(PlayerColor.Black, RandomNum(NeedValidationColor.None)));
                Pieces.Add(new Pawn(PlayerColor.White, RandomNum(NeedValidationColor.None)));
            }
        }

        /// <summary>
        /// Set all possible cells of the board
        /// </summary>
        public void SetCells()
        {
            for (int i = 1; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    Coordinates.Add(new Coordinate(i, j));
                }
            }
            Coordinates = Util.Useful.MessUpList(Coordinates);
        }

        /// <summary>
        /// Returns the coordinates according to a random number
        /// </summary>
        /// <param name="valid"></param>
        /// <returns></returns>
        public Coordinate RandomNum(NeedValidationColor valid)
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            bool isReturn = true;
            Coordinate devCoor = null;
            do
            {
                int n = random.Next(0, 31);
                devCoor = Coordinates[n];

                if (valid == NeedValidationColor.None)
                    isReturn = false;
                else
                {
                    if ((valid == NeedValidationColor.White && (devCoor.Row + devCoor.Column) % 2 == 0) || (valid == NeedValidationColor.Black && (devCoor.Row + devCoor.Column) % 2 == 1))
                        isReturn = true;
                    else
                        isReturn = false;
                }
            } while (isReturn);

            Coordinates.Remove(devCoor);
            return devCoor;
        }

       /// <summary>
        /// Move a piece on the board, if possible
        /// </summary>
        /// <param name="currentPiece">Piece that is going to move</param>
        /// <param name="newCoordinates">coordinates to move the piece</param>
        public ErrorOnBoard NewMove(Piece currentPiece, Coordinate newCoordinates)
        {
            if (!currentPiece.IsPossibleMovement(newCoordinates))
            {
                return ErrorOnBoard.InvalidMovement;
            }

            if (currentPiece.IsPieceInBetween(this, newCoordinates))
            {
                return ErrorOnBoard.InterposedPiece;
            }

            Piece pieceInSquare = this.SearchPieces(newCoordinates.Column, newCoordinates.Row);

            if (pieceInSquare != null)
            {
                if (pieceInSquare.Color == currentPiece.Color)
                {
                    return ErrorOnBoard.SameColor;
                }
                else
                    this.RemovedPiece(pieceInSquare);
            }
            currentPiece.Coordinates = newCoordinates;
            this.DrawBoard();

            return ErrorOnBoard.None;
        }

    }

    /// <summary>
    /// Possible messages when an event happens when moving the piece
    /// </summary>
    public enum ErrorOnBoard
    {
        None, InvalidMovement, InterposedPiece, SameColor
    }

    /// <summary>
    /// You need to validate the color where the coordinates must have the piece
    /// </summary>
    public enum NeedValidationColor
    {
        Black, White, None
    }

}
