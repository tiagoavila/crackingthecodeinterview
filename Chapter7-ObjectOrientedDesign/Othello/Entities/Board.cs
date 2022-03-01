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

            // also need to check for a valid movement. If I'm player of black pieces,
            // I can only place a piece in a spot where there are white pieces surrounded by black pieces including the spot I want to place the piece

            Pieces[row, column].SetColor(color);

            // logic to handle switch of colors

            return false;
        }
    }
}
