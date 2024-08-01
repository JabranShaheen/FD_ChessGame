using System;
using FD_ChessGame.Abstractions;
using FD_ChessGame.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace FD_ChessGame.Tests
{
    [TestClass]
    public class GameTests
    {
        private Mock<IPlayer> _mockPlayer;
        private Mock<IBoard> _mockBoard;
        private Game _game;

        [TestInitialize]
        public void SetUp()
        {
            _mockPlayer = new Mock<IPlayer>();
            _mockBoard = new Mock<IBoard>();
            _game = new Game(_mockPlayer.Object, _mockBoard.Object);
        }

        [TestMethod]
        public void MovePlayer_MovesPlayerAndChecksLandmines()
        {
            // Arrange
            var playerPosition = new Position(0, 0);
            _mockPlayer.Setup(p => p.Position).Returns(playerPosition);
            _mockBoard.Setup(b => b.IsWithinBounds(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            _mockBoard.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            _mockPlayer.Setup(p => p.MoveUp());

            // Act
            _game.MovePlayer("U");

            // Assert
            _mockPlayer.Verify(p => p.MoveUp(), Times.Once);           
        }

        [TestMethod]
        public void IsGameOver_ReturnsTrue_WhenPlayerHitsMoreThanTwoLandmines()
        {
            // Arrange
            var playerPosition = new Position(1, 1); // Start at a position where landmines can be hit
            _mockPlayer.Setup(p => p.Position).Returns(playerPosition);

            // Simulate that the board has mines and the player hits them
            _mockBoard.Setup(b => b.IsWithinBounds(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            _mockBoard.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            // Act
            for (int i = 0; i < 3; i++)
            {
                // Simulate moving up and hitting a landmine
                _game.MovePlayer("U");
            }

            // Assert
            Assert.IsTrue(_game.IsGameOver(), "The game should be over after hitting more than two landmines.");
        }


        [TestMethod]
        public void IsGameWon_ReturnsTrue_WhenPlayerReachesTopWithoutTooManyLandmines()
        {
            // Arrange
            var playerPosition = new Position(0, 0);
            _mockPlayer.Setup(p => p.Position).Returns(playerPosition);
            _mockBoard.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns(false);

            // Act
            bool result = _game.IsGameWon();

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsGameWon_ReturnsFalse_WhenPlayerHitsTooManyLandmines()
        {
            // Arrange
            var playerPosition = new Position(1, 1); // Start at a position where landmines can be hit
            _mockPlayer.Setup(p => p.Position).Returns(playerPosition);

            // Simulate that the board has mines and the player hits them
            _mockBoard.Setup(b => b.IsWithinBounds(It.IsAny<int>(), It.IsAny<int>())).Returns(true);
            _mockBoard.Setup(b => b.IsMine(It.IsAny<int>(), It.IsAny<int>())).Returns(true);

            // Act
            for (int i = 0; i < 3; i++)
            {
                // Simulate moving up and hitting a landmine
                _game.MovePlayer("U");
            }

            // Assert
            Assert.IsFalse(_game.IsGameWon());
        }
    }
}
