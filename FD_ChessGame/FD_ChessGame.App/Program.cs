using System;
using FD_ChessGame.Abstractions;
using FD_ChessGame.Implementations;

namespace FD_ChessGame.App
{
    class Program
    {
        static void Main(string[] args)
        {
            int boardSize = 8;
            int mineCount = 10;

            var position = new Position(0, 0);
            IPlayer player = new Player(position, boardSize);
            IBoard board = new Board(boardSize, new MinePlacer());
            IGame game = new Game(player, board);

            board.PlaceMines(mineCount);

            while (!game.IsGameOver())
            {
                DisplayGameStatus(player, board);

                Console.WriteLine("Enter move (U/D/L/R): ");
                string input = Console.ReadLine();
                if (input != null)
                {
                    try
                    {
                        game.MovePlayer(input);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            if (game.IsGameWon())
            {
                Console.WriteLine("Congratulations! You won the game!");
            }
            else
            {
                Console.WriteLine("Game over! You lost.");
            }
        }

        private static void DisplayGameStatus(IPlayer player, IBoard board)
        {
            Console.Clear();
            Console.WriteLine("Current Board: Just for testing logic; mines are displayed.");

            for (int row = board.Size - 1; row >= 0; row--)
            {
                for (int col = 0; col < board.Size; col++)
                {
                    if (player.Position.Row == row && player.Position.Column == col)
                    {
                        Console.Write("P ");
                    }
                    else
                    {
                        Console.Write(board.IsMine(row, col) ? "M " : ". ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine($"Player Position: Row {player.Position.Row}, Column {player.Position.Column}");
        }
    }
}
