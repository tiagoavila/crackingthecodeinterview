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
        public static string ToShortString(this PieceColorEnum color)
        {
            switch (color)
            {
                case PieceColorEnum.White:
                    return "W ";
                case PieceColorEnum.Black:
                    return "B ";
                default: return "- ";
            }
        }

        public static PieceColorEnum GetOppositeColor(this PieceColorEnum color)
        {
            return color == PieceColorEnum.White ? PieceColorEnum.Black : PieceColorEnum.White;
        }
    }
}
