using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class Landmine
    {
        public Position Position { get; private set; }

        public Landmine(Position position)
        {
            Position = position;
        }

        public bool IsAtPosition(Position position)
        {
            return Position.Row == position.Row && Position.Column == position.Column;
        }
    }
}
