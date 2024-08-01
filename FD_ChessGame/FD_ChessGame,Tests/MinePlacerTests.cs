using System;
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
            boardMock.Setup(b => b.IsWithinBounds(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            boardMock.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns(false);
            var minePlacer = new MinePlacer();

            // Act
            minePlacer.PlaceMines(boardMock.Object, mineCount);

            // Assert
            // Verify that the PlaceMines method is called the number of times specified by mineCount
            // Here we are verifying that the method call to PlaceMines is happening the expected number of times
            boardMock.Verify(b => b.PlaceMines(It.IsAny<int>()), Times.Exactly(mineCount));
        }

        [TestMethod]
        public void PlaceMines_DoesNotOverlapMines()
        {
            // Arrange
            int mineCount = 10;
            var boardMock = new Mock<IBoard>();
            var random = new Random();
            var placedMines = new HashSet<(int, int)>();
            boardMock.Setup(b => b.IsWithinBounds(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            boardMock.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns((int row, int column) => !placedMines.Add((row, column)));

            var minePlacer = new MinePlacer();

            // Act
            minePlacer.PlaceMines(boardMock.Object, mineCount);

            // Assert
            Assert.AreEqual(mineCount, placedMines.Count);
        }
    }
}
