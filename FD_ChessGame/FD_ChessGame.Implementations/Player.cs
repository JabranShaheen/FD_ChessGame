using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class Player : IPlayer
    {
        public Position Position { get; private set; }
        private readonly int _boardSize;

        public Player(Position startPosition, int boardSize)
        {
            Position = startPosition;
            _boardSize = boardSize;
        }

        public void MoveUp()
        {
            if (Position.Row < _boardSize - 1)
            {
                Position.Row += 1;
            }
        }

        public void MoveDown()
        {
            if (Position.Row > 0)
            {
                Position.Row -= 1;
            }
        }

        public void MoveLeft()
        {
            if (Position.Column > 0)
            {
                Position.Column -= 1;
            }
        }

        public void MoveRight()
        {
            if (Position.Column < _boardSize - 1)
            {
                Position.Column += 1;
            }
        }
    }
}
