using Othello.Enums;

namespace Othello.Entities
{
    public class Piece
    {
        public Piece(PieceColorEnum color)
        {
            Color = color;
        }

        public PieceColorEnum Color { get; private set; }

        public void SetColor(PieceColorEnum color)
        {
            this.Color = color;
        }

        public void SwitchColor()
        {
            Color = Color == PieceColorEnum.White ? PieceColorEnum.Black : PieceColorEnum.White;
        }
    }
}
