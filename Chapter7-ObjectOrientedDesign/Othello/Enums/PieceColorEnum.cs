namespace Othello.Enums
{
    public enum PieceColorEnum
    {
        Empty,
        White,
        Black
    }

    public static class PieceColorEnumExtensions
    {
        public static string ToShortString(this PieceColorEnum pieceColorEnum)
        {
            switch (pieceColorEnum)
            {
                case PieceColorEnum.White:
                    return "W ";
                case PieceColorEnum.Black:
                    return "B ";
                default: return "- ";
            }
        }
    }
}
