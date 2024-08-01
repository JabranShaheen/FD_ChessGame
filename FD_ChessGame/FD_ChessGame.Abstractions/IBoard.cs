namespace FD_ChessGame.Abstractions
{
    public interface IBoard
    {
        int Size { get; }
        void PlaceMines(int mineCount);
        bool IsMine(int row, int column);
        bool IsWithinBounds(int row, int column);
    }
}
