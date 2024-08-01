using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Implementations
{
    public class Landmine
    {
        // Position of the landmine on the board
        public Position Position { get; private set; }

        // Constructor to initialize the position of the landmine
        public Landmine(Position position)
        {
            Position = position;
        }

        // Method to determine if the landmine is at a specific position
        public bool IsAtPosition(Position position)
        {
            // Implementation will be added later
            return false;
        }
    }
}
