using Minesweeper.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Core.Entities
{
    public class Board
    {
        public Board(int boardSize, int numberOfBombs)
        {
            BoardSize = boardSize;
            NumberOfBombs = numberOfBombs;
            Cells = new Cell[boardSize, boardSize];
            CellBombs = new List<Cell>(numberOfBombs);
        }

        public int BoardSize { get; private set; }
        public int NumberOfBombs { get; private set; }
        public Cell[,] Cells { get; private set; }
        public ICollection<Cell> CellBombs { get; private set; }
        

        public void InitializeBoard()
        {
            PlaceBombs();
            SetNumberedCells();
        }

        private void PlaceBombs()
        {
            int numberOfCells = BoardSize * BoardSize;

            // Place bombs on the first N cells, where N is the value of the property NumberOfBombs
            for (int index = 0; index < numberOfCells; index++)
            {
                int row = index / BoardSize;
                int column = (index - row * BoardSize) % BoardSize;

                Cell cell = new(row, column);
                if (index < NumberOfBombs)
                {
                    cell.SetCellType(CellTypeEnum.Bomb);
                    CellBombs.Add(cell);
                }

                Cells[row, column] = cell;
            }

            Random random = new();

            //for (int index1 = 0; index1 < NumberOfBombs; index1++)
            //{
            //    int index2 = index1 + random.Next(numberOfCells - index1);
            //    if (index1 != index2)
            //    {
            //        // Get cell at index1
            //        int row1 = index1 / BoardSize;
            //        int column1 = (index1 - row1 * BoardSize) % BoardSize;
            //        Cell cell1 = Cells[row1, column1];

            //        // Get cell at index2
            //        int row2 = index2 / BoardSize;
            //        int column2 = (index2 - row2 * BoardSize) % BoardSize;
            //        Cell cell2 = Cells[row2, column2];


            //    }
            //}
        }

        private void SetNumberedCells()
        {

        }
    }
}
