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
        public static string ToShortString(this PieceColorEnum color) => color switch
        {
            PieceColorEnum.White => "W ",
            PieceColorEnum.Black => "B ",
            _ => "- ",
        };

        public static PieceColorEnum GetOppositeColor(this PieceColorEnum color)
        {
            return color == PieceColorEnum.White ? PieceColorEnum.Black : PieceColorEnum.White;
        }
    }
}
