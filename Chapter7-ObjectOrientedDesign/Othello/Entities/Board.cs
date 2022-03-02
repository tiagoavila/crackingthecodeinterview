using Othello.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello.Entities
{
    public class Board
    {
        const int NUMBER_OF_ROWS = 8;
        const int NUMBER_OF_COLUMNS = 8;

        public Board()
        {
            Pieces = new Piece[NUMBER_OF_ROWS, NUMBER_OF_COLUMNS];
        }

        public Piece[,] Pieces { get; set; }

        private int whiteCount = 0;
        private int blackCount = 0;

        public void InitializeBoard()
        {
            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    if ((row == 3 && column == 3) || (row == 4 && column == 4))
                    {
                        Pieces[row, column] = new Piece(EnumPieceColor.Black);
                    }
                    else if ((row == 3 && column == 4) || (row == 4 && column == 3))
                    {
                        Pieces[row, column] = new Piece(EnumPieceColor.White);
                    }
                    else
                    {
                        Pieces[row, column] = new Piece(EnumPieceColor.Empty);
                    }
                }
            }

            whiteCount = 0;
            blackCount = 0;
        }

        public bool PlaceColor(int row, int column, EnumPieceColor color)
        {
            if (Pieces[row, column].Color != EnumPieceColor.Empty)
            {
                return false;
            }

            // check neighboors, if no neighboor has a color it won't allow to place the piece
            if (!AreThereAnyNeighboorWithColors(row, column))
            {
                return false;
            }

            // also need to check for a valid movement. If I'm player of black pieces,
            // I can only place a piece in a spot where there are white pieces surrounded by black pieces including the spot I want to place the piece

            Pieces[row, column].SetColor(color);

            // logic to handle switch of colors

            return false;
        }

        /// <summary>
        /// It checks the top, bottom, left and right neighboors checking if any of them has a color
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private bool AreThereAnyNeighboorWithColors(int row, int column)
        {
            Piece? topNeighboor = row > 0 ? Pieces[row - 1, column] : null;
            Piece? bottomNeighboor = row < NUMBER_OF_ROWS ? Pieces[row + 1, column] : null;
            Piece? leftNeighboor = column > 0 ? Pieces[row, column - 1] : null;
            Piece? rightNeighboor = column < NUMBER_OF_COLUMNS ? Pieces[row, column + 1] : null;

            if (topNeighboor != null)
            {
                if (topNeighboor.Color != EnumPieceColor.Empty)
                {
                    return true;
                }
            }

            if (bottomNeighboor != null)
            {
                if (bottomNeighboor.Color != EnumPieceColor.Empty)
                {
                    return true;
                }
            }

            if (leftNeighboor != null)
            {
                if (leftNeighboor.Color != EnumPieceColor.Empty)
                {
                    return true;
                }
            }

            if (rightNeighboor != null)
            {
                if (rightNeighboor.Color != EnumPieceColor.Empty)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
