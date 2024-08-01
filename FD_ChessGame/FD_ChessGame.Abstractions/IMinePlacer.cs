namespace FD_ChessGame.Abstractions
{
    public interface IMinePlacer
    {
        void PlaceMines(IBoard board, int mineCount);
    }
}
