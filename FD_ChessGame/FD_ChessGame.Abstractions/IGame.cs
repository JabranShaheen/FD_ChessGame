namespace FD_ChessGame.Abstractions
{
    public interface IGame
    {
        void Start();
        void MovePlayer(char direction);
        bool IsGameOver { get; }
        bool IsGameWon { get; }
    }
}
