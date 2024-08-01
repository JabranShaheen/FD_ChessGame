using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class Player : IPlayer
    {
        public Position Position { get; private set; }

        public Player(Position startPosition)
        {
            Position = startPosition;
        }

        public void MoveUp()
        {
            Position.Row += 1;
        }

        public void MoveDown()
        {
            Position.Row -= 1;
        }

        public void MoveLeft()
        {
            Position.Column -= 1;
        }

        public void MoveRight()
        {
            Position.Column += 1;
        }
    }
}
