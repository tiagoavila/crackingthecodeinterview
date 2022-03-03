using Othello.Enums;

namespace Othello.Entities
{
    public class Neighbor
    {
        public Neighbor(Piece piece, DirectionEnum direction)
        {
            Piece = piece;
            Direction = direction;
        }

        public Piece Piece { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}
