using Classes;
using Classes.Pieces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chess
{
    public class ChessGame : IChessGame
    {

        public ChessGame()
        {

        }

        /// <summary>
        /// Start a new game
        /// </summary>
        public void Start()
        {
            Board newBoard = new Board();
            string randomOption = null;
            do
            {
                Console.WriteLine();
                Console.WriteLine(Resource.RandomPlay + " Y / N");
                randomOption = Console.ReadLine();
                randomOption = randomOption.ToUpper();
            }
            while (randomOption != "Y" && randomOption != "N");


            if (randomOption == "Y")
                newBoard.InitialicePiecesRandom();
            else
                newBoard.InitialicePieces();

            bool again = false;
            do
            {
                newBoard.DrawBoard();

                Piece currentPiece = null;
                while (currentPiece == null)
                {
                    Coordinate currentCoordinates = ReadNewCoordinates();
                    currentPiece = newBoard.SearchPieces(currentCoordinates.Column, currentCoordinates.Row);
                    if (currentPiece != null)
                    {
                        Console.WriteLine(Resource.SelectedPiece + " " + currentPiece.GetType().Name.ToString() + " - " + currentPiece.Color.ToString());
                        Console.WriteLine();
                        Console.WriteLine(Resource.DestinationCoordinates);
                        Coordinate newCoordinates = ReadNewCoordinates();
                        Console.WriteLine();

                        ShowsErrorMessage(newBoard.NewMove(currentPiece, newCoordinates));
                    }
                    else
                    {
                        Console.WriteLine(Resource.CoordinateNotValid);
                        Console.WriteLine();
                    }
                };

                Console.ForegroundColor = ConsoleColor.White;

                string continueOption = null;
                Console.WriteLine(Resource.WantToContinue + " Y / N");
                continueOption = Console.ReadLine();
                continueOption = continueOption.ToUpper();
                if (continueOption == "Y")
                {
                    again = true;
                    //Console.Clear();
                }
                else
                    again = false;


            } while (again);
        }

        /// <summary>
        /// Returns the entered coordinates
        /// </summary>
        /// <returns></returns>
        public Coordinate ReadNewCoordinates()
        {
            Console.WriteLine();
            Console.WriteLine(Resource.ReadRow);
            string filaString = Console.ReadLine();

            while (!Util.Useful.IsNumeric(filaString))
            {
                Console.WriteLine(Resource.ErrorConvertionNumeric);
                filaString = Console.ReadLine();
            }

            int filaInt = Convert.ToInt32(filaString);

            while (filaInt <= 0 || filaInt > 8)
            {
                Console.WriteLine(Resource.ErrorRow);
                filaString = Console.ReadLine();
                filaInt = Convert.ToInt32(filaString);
            }

            Console.WriteLine(Resource.ReadColumn);
            string colString = Console.ReadLine();

            int columnInt = Util.Useful.ConvertLetterRowToNumber(colString);
            while (columnInt == 0)
            {
                Console.WriteLine();
                Console.WriteLine(Resource.ErrorColumn);
                Console.WriteLine();
                colString = Console.ReadLine();
                columnInt = Util.Useful.ConvertLetterRowToNumber(colString);
            }

            Coordinate newCoord = new Coordinate(columnInt, filaInt);
            Console.WriteLine();

            return newCoord;
        }

        /// <summary>
        /// Shows the error message
        /// </summary>
        /// <param name="_error">Error</param>
        public void ShowsErrorMessage(ErrorOnBoard _error)
        {
            switch (_error)
            {
                case ErrorOnBoard.InterposedPiece:
                    Console.WriteLine(Resource.InterposedPiece);
                    Console.ReadLine();
                    break;

                case ErrorOnBoard.InvalidMovement:
                    Console.WriteLine(Resource.InvalidMovement);
                    Console.ReadLine();
                    break;

                case ErrorOnBoard.SameColor:
                    Console.WriteLine(Resource.SameColor);
                    Console.ReadLine();
                    break;
            }
        }

    }
}
