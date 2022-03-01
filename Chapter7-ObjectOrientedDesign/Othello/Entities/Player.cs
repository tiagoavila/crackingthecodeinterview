using Othello.Enums;

namespace Othello.Entities
{
    public class Player
    {
        public Player(EnumPieceColor color)
        {
            Color = color;
        }

        public EnumPieceColor Color { get; private set; }
    }
}
