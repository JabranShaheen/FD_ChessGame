using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class Board : IBoard
    {
        private readonly IMinePlacer _minePlacer;
        private readonly bool[,] _mines; // 2D array to represent mine locations
        public int Size { get; private set; }

        public Board(int size, IMinePlacer minePlacer)
        {
            Size = size;
            _minePlacer = minePlacer;
            _mines = new bool[Size, Size];
        }

        public void PlaceMines(int mineCount)
        {
            _minePlacer.PlaceMines(this, mineCount);
        }

        public bool IsMine(int row, int column)
        {
            if (!IsWithinBounds(row, column))
                throw new ArgumentOutOfRangeException();

            return _mines[row, column];
        }

        public bool IsWithinBounds(int row, int column)
        {
            return row >= 0 && row < Size && column >= 0 && column < Size;
        }

        public void InitializeMines(int mineCount)
        {
            PlaceMines(mineCount);
        }
        public void SetMine(int row, int column)
        {
            if (!IsWithinBounds(row, column))
                throw new ArgumentOutOfRangeException("Position out of bounds.");

            _mines[row, column] = true;
        }
    }
}
