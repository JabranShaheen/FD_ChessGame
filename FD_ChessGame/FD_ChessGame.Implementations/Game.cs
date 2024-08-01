using System;
using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class Game : IGame
    {
        public IPlayer Player { get; private set; }
        public IBoard Board { get; private set; }
        private int _landminesHit;

        public Game(IPlayer player, IBoard board)
        {
            Player = player ?? throw new ArgumentNullException(nameof(player));
            Board = board ?? throw new ArgumentNullException(nameof(board));
            _landminesHit = 0;
        }

        public void MovePlayer(string direction)
        {
            switch (direction.ToUpper())
            {
                case "U":
                    Player.MoveUp();
                    break;
                case "D":
                    Player.MoveDown();
                    break;
                case "L":
                    Player.MoveLeft();
                    break;
                case "R":
                    Player.MoveRight();
                    break;
                default:
                    throw new ArgumentException("Invalid direction");
            }

            var position = Player.Position;
            if (Board.IsWithinBounds(position.Row, position.Column) && Board.IsMine(position.Row, position.Column))
            {
                _landminesHit++;
            }
        }

        public bool IsGameOver()
        {
            return _landminesHit > 2 || Player.Position.Row == 0;
        }

        public bool IsGameWon()
        {
            return Player.Position.Row == 0 && _landminesHit <= 2;
        }
    }
}
