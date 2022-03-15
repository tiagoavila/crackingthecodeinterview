namespace Minesweeper.Core.Enums
{
    public enum CellTypeEnum
    {
        Blank,
        Number,
        Bomb
    }

    public static class CellTypeEnumExtensions
    {
        public static string ToShortString(this CellTypeEnum cellType, Cell cell) => cellType switch
        {
            CellTypeEnum.Blank => "-",
            CellTypeEnum.Number => cell.NumberOfSurroudingBombs.ToString(),
            CellTypeEnum.Bomb => "*",
            _ => string.Empty
        };
    }
}
