using Minesweeper.Core.Enums;

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

        private readonly (int rowDisplacement, int columnDisplacement)[] _neighboorsPosition = new[] { (-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1) };
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
            List<Cell> neighboors = new(_neighboorsPosition.Length);

            foreach (var (rowDisplacement, columnDisplacement) in _neighboorsPosition)
            {
                int neighboorRow = Row + rowDisplacement;
                int neighboorColumn = Column + columnDisplacement;

                if (neighboorRow >= 0 && neighboorRow < boardSize && neighboorColumn >= 0 && neighboorColumn < boardSize)
                {
                    neighboors.Add(cells[neighboorRow, neighboorColumn]);
                }
            }

            return neighboors;
        }
    }
}