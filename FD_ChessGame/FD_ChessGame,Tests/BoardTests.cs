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

            // Act
            _board.InitializeMines(mineCount);

            // Assert
            _mockMinePlacer.Verify(mp => mp.PlaceMines(_board, mineCount), Times.Once);
        }

        [TestMethod]
        public void SetMine_SetsMineAtSpecifiedLocation()
        {
            // Arrange
            int row = 2;
            int column = 3;

            // Act
            _board.SetMine(row, column);

            // Assert
            Assert.IsTrue(_board.IsMine(row, column));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetMine_ThrowsException_WhenOutOfBounds_Row()
        {
            // Act
            _board.SetMine(-1, 0); // Invalid row
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void SetMine_ThrowsException_WhenOutOfBounds_Column()
        {
            // Act
            _board.SetMine(0, -1); // Invalid column
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
