namespace FD_ChessGame.Abstractions
{
    public interface IGame
    {
        IPlayer Player { get; }
        IBoard Board { get; }
        void MovePlayer(string direction);
        bool IsGameOver();
        bool IsGameWon();
    }
}
