using Minesweeper.Core.Enums;
using Minesweeper.Core.ValueObjects;

namespace Minesweeper.Core
{
    public class Cell
    {
        public Cell(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public Cell(int row, int column, bool isBomb)
        {
            Row = row;
            Column = column;
            IsBomb = isBomb;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
        public CellTypeEnum CellType => IsBomb ? CellTypeEnum.Bomb : NumberOfSurroudingBombs > 0 ? CellTypeEnum.Number : CellTypeEnum.Blank;
        public bool IsExposed { get; private set; }
        public bool IsGuess { get; private set; }
        public int NumberOfSurroudingBombs { get; private set; }
        public bool IsBomb { get; private set; }

        public void SetIsBomb()
        {
            IsBomb = true;
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

        public void IncreaseNumberOfSurroudingBombs()
        {
            NumberOfSurroudingBombs += 1;
        }

        public IEnumerable<Cell> GetNeighboors(int boardSize, Cell[,] cells)
        {
            List<Cell> neighboors = new(NeighboorsPosition.NeighboorsDisplacement.Length);

            foreach (var (rowDisplacement, columnDisplacement) in NeighboorsPosition.NeighboorsDisplacement)
            {
                int neighboorRow = Row + rowDisplacement;
                int neighboorColumn = Column + columnDisplacement;

                if (IsNeighboorInBounds(boardSize, neighboorRow, neighboorColumn))
                {
                    neighboors.Add(cells[neighboorRow, neighboorColumn]);
                }
            }

            return neighboors;
        }

        public string ToShortString() => CellType switch
        {
            CellTypeEnum.Blank => "-",
            CellTypeEnum.Number => NumberOfSurroudingBombs.ToString(),
            CellTypeEnum.Bomb => "*",
            _ => string.Empty
        };

        public bool IsNeighboorInBounds(int boardSize, int neighboorRow, int neighboorColumn)
        {
            return neighboorRow >= 0 && neighboorRow < boardSize && neighboorColumn >= 0 && neighboorColumn < boardSize;
        }
    }
}