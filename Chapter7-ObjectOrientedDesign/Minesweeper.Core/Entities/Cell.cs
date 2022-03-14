using Minesweeper.Core.Enums;

namespace Minesweeper.Core
{
    public class Cell
    {
        private Cell()
        {
            CellType = CellTypeEnum.Blank;
        }

        public Cell(int row, int column) : this()
        {
            Row = row;
            Column = column;
        }

        public Cell(int row, int column, CellTypeEnum cellType)
        {
            Row = row;
            Column = column;
            CellType = cellType;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public CellTypeEnum CellType { get; private set; }
        public bool IsExposed { get; private set; }
        public bool IsGuess { get; private set; }
        public int NumberOfSurroudingBombs { get; private set; }
        public bool IsBomb => CellType == CellTypeEnum.Bomb;

        public void SetCellType(CellTypeEnum cellType)
        {
            CellType = cellType;
        }

        public void SetRowAndColumn(int newRow, int newColumn)
        {
            Row = newRow;
            Column = newColumn;
        }

        public void MarkAsExposed() 
        { 
            IsExposed = true;
        }

        public void MarkAsGuess()
        {
            IsGuess = true;
        }

        public void SetNumberOfSurroudingBombs(int numberOfSurroudingBombs)
        {
            NumberOfSurroudingBombs = numberOfSurroudingBombs;
        }

        public IEnumerable<Cell> GetNeighboors(int boardSize)
        {
            return new List<Cell>();
        }
    }
}