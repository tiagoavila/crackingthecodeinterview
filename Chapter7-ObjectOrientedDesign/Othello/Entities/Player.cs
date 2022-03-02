using Othello.Enums;

namespace Othello.Entities
{
    public class Player
    {
        public Player(PieceColorEnum color)
        {
            Color = color;
        }

        public PieceColorEnum Color { get; private set; }
    }
}
