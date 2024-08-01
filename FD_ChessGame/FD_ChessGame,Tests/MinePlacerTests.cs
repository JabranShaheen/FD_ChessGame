using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FD_ChessGame.Abstractions;
using FD_ChessGame.Implementations;

namespace FD_ChessGame.Tests
{
    [TestClass]
    public class MinePlacerTests
    {
        [TestMethod]
        public void PlaceMines_PlacesCorrectNumberOfMines()
        {
            // Arrange
            int mineCount = 5;
            var boardMock = new Mock<IBoard>();

            // Setup the board to always be within bounds and to never have a mine
            boardMock.Setup(b => b.IsWithinBounds(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            boardMock.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            var minePlacer = new MinePlacer();

            // Act
            minePlacer.PlaceMines(boardMock.Object, mineCount);

            // Assert
            // Verify that SetMine is called exactly mineCount times
            boardMock.Verify(b => b.SetMine(It.IsAny<int>(), It.IsAny<int>()), Times.Exactly(mineCount));
        }
    }
}
