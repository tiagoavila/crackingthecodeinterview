using Othello.Enums;

namespace Othello.Entities
{
    public class Piece
    {
        public Piece(EnumPieceColor color)
        {
            Color = color;
        }

        public EnumPieceColor Color { get; private set; }

        public void SetColor(EnumPieceColor color)
        {
            this.Color = color;
        }

        public void SwitchColor()
        {
            Color = Color == EnumPieceColor.White ? EnumPieceColor.Black : EnumPieceColor.White;
        }
    }
}
