using System;
using FD_ChessGame.Abstractions;
using FD_ChessGame.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FD_ChessGame.Tests
{
    [TestClass]
    public class BoardTests
    {
        private Mock<IMinePlacer> _mockMinePlacer;
        private Board _board;

        [TestInitialize]
        public void SetUp()
        {
            // Create a mock instance of IMinePlacer
            _mockMinePlacer = new Mock<IMinePlacer>();

            // Initialize Board with size 8 and the mocked IMinePlacer
            _board = new Board(8, _mockMinePlacer.Object);
        }

        [TestMethod]
        public void PlaceMines_CallsMinePlacer()
        {
            // Arrange
            int mineCount = 10;

            // Act
            _board.PlaceMines(mineCount);

            // Assert
            _mockMinePlacer.Verify(mp => mp.PlaceMines(_board, mineCount), Times.Once);
        }

        [TestMethod]
        public void InitializeMines_CallsPlaceMines()
        {
            // Arrange
            int mineCount = 10;
            var mockBoard = new Mock<IBoard>();

            // Act
            _board.InitializeMines(mineCount);

            // Assert
            _mockMinePlacer.Verify(mp => mp.PlaceMines(_board, mineCount), Times.Once);
        }

        [TestMethod]
        public void IsMine_OutsideBounds_ThrowsException()
        {
            // Arrange
            int invalidRow = -1;
            int invalidColumn = -1;

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _board.IsMine(invalidRow, invalidColumn));
        }

        [TestMethod]
        public void IsWithinBounds_ReturnsFalseForInvalidPosition()
        {
            // Arrange
            int invalidRow = -1;
            int invalidColumn = -1;

            // Act
            bool result = _board.IsWithinBounds(invalidRow, invalidColumn);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsWithinBounds_ReturnsTrueForValidPosition()
        {
            // Arrange
            int validRow = 0;
            int validColumn = 0;

            // Act
            bool result = _board.IsWithinBounds(validRow, validColumn);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
