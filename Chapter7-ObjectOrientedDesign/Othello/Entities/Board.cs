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

            // check neighbors, if no neighbor has a color it won't allow to place the piece
            var (thereAreAnyNeighborWithColor, topNeighbor, bottomNeighbor, leftNeighbor, rightNeighbor) = IsThereAnyNeighborWithColors(row, column);
            if (!thereAreAnyNeighborWithColor)
            {
                return false;
            }

            // also need to check for a valid movement. If I'm player of black pieces,
            // I can only place a piece in a spot where there are white pieces surrounded by black pieces including the spot I want to place the piece
            if (!IsThereAnyNeighborWithAnOppositeColor(topNeighbor, bottomNeighbor, leftNeighbor, rightNeighbor, color))
            {
                return false;
            }

            Pieces[row, column].SetColor(color);

            // logic to handle switch of colors

            return false;
        }

        /// <summary>
        /// It checks the top, bottom, left and right neighbors checking if any of them has a color
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        private (
            bool ThereAreAnyNeighborWithColor,
            Piece? TopNeighbor,
            Piece? BottomNeighbor,
            Piece? LeftNeighbor,
            Piece? RightNeighbor
            ) IsThereAnyNeighborWithColors(int row, int column)
        {
            bool thereAreAnyNeighborWithColor = false;
            var (topNeighbor, bottomNeighbor, leftNeighbor, rightNeighbor) = GetNeighborsOfaSpot(row, column);

            if (topNeighbor != null)
            {
                if (topNeighbor.Color != EnumPieceColor.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            if (bottomNeighbor != null)
            {
                if (bottomNeighbor.Color != EnumPieceColor.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            if (leftNeighbor != null)
            {
                if (leftNeighbor.Color != EnumPieceColor.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            if (rightNeighbor != null)
            {
                if (rightNeighbor.Color != EnumPieceColor.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            return (thereAreAnyNeighborWithColor, topNeighbor, bottomNeighbor, leftNeighbor, rightNeighbor);
        }

        private (Piece? TopNeighbor, Piece? BottomNeighbor, Piece? LeftNeighbor, Piece? RightNeighbor) GetNeighborsOfaSpot(int row, int column)
        {
            Piece? topNeighbor = row > 0 ? Pieces[row - 1, column] : null;
            Piece? bottomNeighbor = row < NUMBER_OF_ROWS ? Pieces[row + 1, column] : null;
            Piece? leftNeighbor = column > 0 ? Pieces[row, column - 1] : null;
            Piece? rightNeighbor = column < NUMBER_OF_COLUMNS ? Pieces[row, column + 1] : null;

            return (topNeighbor, bottomNeighbor, leftNeighbor, rightNeighbor);
        }

        /// <summary>
        /// Check for a valid movement. If I'm player of black pieces, 
        /// I can only place a piece in a spot where there are white pieces surrounded by black pieces including the spot I want to place the piece
        /// </summary>
        /// <param name="topNeighbor"></param>
        /// <param name="bottomNeighbor"></param>
        /// <param name="leftNeighbor"></param>
        /// <param name="rightNeighbor"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        private bool IsThereAnyNeighborWithAnOppositeColor(Piece? topNeighbor,
            Piece? bottomNeighbor,
            Piece? leftNeighbor,
            Piece? rightNeighbor, EnumPieceColor color)
        {
            EnumPieceColor oppositeColor = color == EnumPieceColor.White ? EnumPieceColor.Black : EnumPieceColor.White;

            if (topNeighbor != null)
            {
                if (topNeighbor.Color == oppositeColor)
                {
                    return true;
                }
            }

            if (bottomNeighbor != null)
            {
                if (bottomNeighbor.Color == oppositeColor)
                {
                    return true;
                }
            }

            if (leftNeighbor != null)
            {
                if (leftNeighbor.Color == oppositeColor)
                {
                    return true;
                }
            }

            if (rightNeighbor != null)
            {
                if (rightNeighbor.Color == oppositeColor)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
