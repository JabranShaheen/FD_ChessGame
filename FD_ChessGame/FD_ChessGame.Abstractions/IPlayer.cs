namespace FD_ChessGame.Abstractions
{
    public interface IPlayer
    {
        IPosition Position { get; }
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
