using System;
using System.Collections.Generic;
using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class MinePlacer : IMinePlacer
    {
        public void PlaceMines(IBoard board, int mineCount)
        {
            var random = new Random();
            var placedMines = 0;

            while (placedMines < mineCount)
            {
                int row = random.Next(0, board.Size);
                int column = random.Next(0, board.Size);

                if (board.IsWithinBounds(row, column) && !board.IsMine(row, column))
                {
                    board.PlaceMines(mineCount); // Assuming this method places the mines at specified locations
                    placedMines++;
                }
            }
        }
    }
}
