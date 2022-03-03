namespace Othello.Enums
{
    public enum DirectionEnum
    {
        Top,
        Bottom,
        Left,
        Right
    }

    public static class DirectionExtensions
    {
        /// <summary>
        /// Returns the displament value for row and column based on the current direction. 
        /// Example A: If direction is Top, the displacement is the value of the row - 1 and column remains the same.
        /// Example B: If direction is Right, the displacement is the value of the column + 1 and row remains the same.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="rowAfterDisplacement"></param>
        /// <param name="columnAfterDisplacement"></param>
        public static void GetRowAndColumnDisplacement(this DirectionEnum direction, int row, int column, out int rowAfterDisplacement, out int columnAfterDisplacement)
        {
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

            rowAfterDisplacement = row;
            columnAfterDisplacement = column;
        }

        /// <summary>
        /// Get the stop condition to avoid getting an element of a position that's outside the Board and also avoid the Error: Index was outside the bounds of the array
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="maxNumberOfRows"></param>
        /// <param name="maxNumberOfColumns"></param>
        /// <returns></returns>
        public static Func<bool> GetStopCondition(this DirectionEnum direction, int row, int column, int maxNumberOfRows, int maxNumberOfColumns)
        {
            switch (direction)
            {
                case DirectionEnum.Top:
                    return () => row > 0;

                case DirectionEnum.Bottom:
                    return () => row < maxNumberOfRows;

                case DirectionEnum.Left:
                    return () => column > 0;

                case DirectionEnum.Right:
                    return () => column < maxNumberOfColumns;

                default:
                    return () => false;
            }
        }

        /// <summary>
        /// Get the limit index that a method can go for the row and column based on the current direction.
        /// Example A: If direction is Top, the limit is row = 0.
        /// Example B: If direction is Right, the limit is the number of columns of the board
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="numberOfRows"></param>
        /// <param name="numberOfColumns"></param>
        /// <param name="rowLimit"></param>
        /// <param name="columnLimit"></param>
        public static void GetRowAndColumnLimit(this DirectionEnum direction, int numberOfRows, int numberOfColumns, out int? rowLimit, out int? columnLimit)
        {
            rowLimit = null;
            columnLimit = null;

            switch (direction)
            {
                case DirectionEnum.Top:
                    rowLimit = 0;
                    break;

                case DirectionEnum.Bottom:
                    rowLimit = numberOfRows;
                    break;

                case DirectionEnum.Left:
                    columnLimit = 0;
                    break;

                case DirectionEnum.Right:
                    columnLimit = numberOfColumns;
                    break;
            }
        }
    }
}
