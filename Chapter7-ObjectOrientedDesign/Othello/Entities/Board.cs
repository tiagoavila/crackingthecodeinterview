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
                        Pieces[row, column] = new Piece(PieceColorEnum.Black);
                    }
                    else if ((row == 3 && column == 4) || (row == 4 && column == 3))
                    {
                        Pieces[row, column] = new Piece(PieceColorEnum.White);
                    }
                    else
                    {
                        Pieces[row, column] = new Piece(PieceColorEnum.Empty);
                    }
                }
            }

            whiteCount = 0;
            blackCount = 0;
        }

        public bool PlaceColor(int row, int column, PieceColorEnum color)
        {
            if (Pieces[row, column].Color != PieceColorEnum.Empty)
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
            var (thereIsAnyNeighborWithOppositeColor, topNeighborHasOppositeColor, bottomNeighborHasOppositeColor, leftNeighborHasOppositeColor, rightNeighborHasOppositeColor)
                = IsThereAnyNeighborWithAnOppositeColor(topNeighbor, bottomNeighbor, leftNeighbor, rightNeighbor, color);

            if (!thereIsAnyNeighborWithOppositeColor)
            {
                return false;
            }

            // check for a chain of opposite colors until find a piece of the same based on the neighbors with opposite colors,
            // if there is a chain like that the piece is allowed to be placed an the pieces in the chain need to be switched
            bool canInsertPiece = false;
            if (topNeighborHasOppositeColor)
            {
                canInsertPiece |= CheckChainOfPiecesAndSwitchNeighborColors(row - 1, column, color, DirectionEnum.Top, 0, null);
            }

            if (bottomNeighborHasOppositeColor)
            {
                canInsertPiece |= CheckChainOfPiecesAndSwitchNeighborColors(row + 1, column, color, DirectionEnum.Bottom, NUMBER_OF_ROWS, null);
            }

            if (leftNeighborHasOppositeColor)
            {
                canInsertPiece |= CheckChainOfPiecesAndSwitchNeighborColors(row, column - 1, color, DirectionEnum.Left, null, 0);
            }

            if (rightNeighborHasOppositeColor)
            {
                canInsertPiece |= CheckChainOfPiecesAndSwitchNeighborColors(row, column + 1, color, DirectionEnum.Right, null, NUMBER_OF_COLUMNS);
            }

            if (canInsertPiece)
            {
                Pieces[row, column].SetColor(color);
            }         

            return canInsertPiece;
        }

        /// <summary>
        /// Return the Pieces of the boards as string, Empty spots return as -, Black pieces as B and White as W
        /// </summary>
        /// <returns></returns>
        public string GetBoardPiecesAsString()
        {
            StringBuilder boardPieces = new();

            for (int row = 0; row < NUMBER_OF_ROWS; row++)
            {
                if (row != 0)
                {
                    boardPieces.Append("| ");
                }

                for (int column = 0; column < NUMBER_OF_COLUMNS; column++)
                {
                    string pieceColorAsString = "- ";
                    if (Pieces[row, column].Color == PieceColorEnum.Black)
                    {
                        pieceColorAsString = "B ";
                    }
                    else if (Pieces[row, column].Color == PieceColorEnum.White)
                    {
                        pieceColorAsString = "W ";
                    }

                    boardPieces.Append(pieceColorAsString);
                }
            }

            return boardPieces.ToString();
        }

        /// <summary>
        /// Check for a chain of pieces with opposite colors until find a piece with the same color,
        /// if there is a chain like that the piece is allowed to be placed an the pieces with opposite colors in the chain will be switched.
        /// As soon as the code finds a piece with the same color as the piece attempting to be placed, in the return of the recursive calls the pieces with opposite colors are already switched.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="color"></param>
        /// <param name="direction"></param>
        /// <param name="rowLimit"></param>
        /// <param name="columnLimit"></param>
        /// <returns></returns>
        private bool CheckChainOfPiecesAndSwitchNeighborColors(int row, int column, PieceColorEnum color, DirectionEnum direction, int? rowLimit, int? columnLimit)
        {
            bool canSwitchNeighborsColorAndPlaceNewPiece = false;
            Piece currentPiece = Pieces[row, column];

            // Found a piece in the chain of pieces with the same color of the one attempting to be inserted, that means we can switch the other neigbors colors and insert the piece
            if (currentPiece != null && currentPiece.Color == color)
            {
                canSwitchNeighborsColorAndPlaceNewPiece = true;
            }

            // Stop condition
            if (canSwitchNeighborsColorAndPlaceNewPiece || (rowLimit.HasValue && row == rowLimit.Value) || (columnLimit.HasValue && column == columnLimit.Value))
            {
                return canSwitchNeighborsColorAndPlaceNewPiece;
            }

            switch (direction)
            {
                case DirectionEnum.Top:
                    row--;
                    break;

                case DirectionEnum.Bottom:
                    row++;
                    break;

                case DirectionEnum.Left:
                    column--;
                    break;

                case DirectionEnum.Right:
                    column++;
                    break;
            }

            //If found one piece of the same color of the target piece, the other pieces can have its color switched
            bool result = CheckChainOfPiecesAndSwitchNeighborColors(row, column, color, direction, rowLimit, columnLimit);
            if (result && currentPiece != null)
            {
                currentPiece.SwitchColor();
            }
            return result;
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
                if (topNeighbor.Color != PieceColorEnum.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            if (bottomNeighbor != null)
            {
                if (bottomNeighbor.Color != PieceColorEnum.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            if (leftNeighbor != null)
            {
                if (leftNeighbor.Color != PieceColorEnum.Empty)
                {
                    thereAreAnyNeighborWithColor = true;
                }
            }

            if (rightNeighbor != null)
            {
                if (rightNeighbor.Color != PieceColorEnum.Empty)
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
        private (bool ThereIsAnyNeighborWithOppositeColor, bool topNeighborHasOppositeColor, bool bottomNeighborHasOppositeColor, bool leftNeighborHasOppositeColor, bool rightNeighborHasOppositeColor)
            IsThereAnyNeighborWithAnOppositeColor(
            Piece? topNeighbor,
            Piece? bottomNeighbor,
            Piece? leftNeighbor,
            Piece? rightNeighbor, PieceColorEnum color)
        {
            bool thereIsAnyNeighborWithOppositeColor = false;
            bool topNeighborHasOppositeColor = false;
            bool bottomNeighborHasOppositeColor = false;
            bool leftNeighborHasOppositeColor = false;
            bool rightNeighborHasOppositeColor = false;

            PieceColorEnum oppositeColor = color == PieceColorEnum.White ? PieceColorEnum.Black : PieceColorEnum.White;

            if (topNeighbor != null)
            {
                if (topNeighbor.Color == oppositeColor)
                {
                    thereIsAnyNeighborWithOppositeColor = true;
                    topNeighborHasOppositeColor = true;
                }
            }

            if (bottomNeighbor != null)
            {
                if (bottomNeighbor.Color == oppositeColor)
                {
                    thereIsAnyNeighborWithOppositeColor = true;
                    bottomNeighborHasOppositeColor = true;
                }
            }

            if (leftNeighbor != null)
            {
                if (leftNeighbor.Color == oppositeColor)
                {
                    thereIsAnyNeighborWithOppositeColor = true;
                    leftNeighborHasOppositeColor = true;
                }
            }

            if (rightNeighbor != null)
            {
                if (rightNeighbor.Color == oppositeColor)
                {
                    thereIsAnyNeighborWithOppositeColor = true;
                    rightNeighborHasOppositeColor = true;
                }
            }

            return (thereIsAnyNeighborWithOppositeColor, topNeighborHasOppositeColor, bottomNeighborHasOppositeColor, leftNeighborHasOppositeColor, rightNeighborHasOppositeColor);
        }
    }
}
