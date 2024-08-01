using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD_ChessGame.Implementations;
using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Tests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_Starts_At_Specified_Position()
        {
            // Arrange
            var position = new Position(7, 0); // Starting at the bottom-left corner
            IPlayer player = new Player(position);

            // Act
            var pos = player.Position;

            // Assert
            Assert.AreEqual(7, pos.Row);
            Assert.AreEqual(0, pos.Column);
        }

        [TestMethod]
        public void Player_Can_Move_Up()
        {
            // Arrange
            var position = new Position(0, 0); // Starting position
            IPlayer player = new Player(position);

            // Act
            player.MoveUp();

            // Assert
            Assert.AreEqual(1, position.Row); // Moving up should decrease the row number
            Assert.AreEqual(0, position.Column); // No change in column
        }

        [TestMethod]
        public void Player_Can_Move_Down()
        {
            // Arrange
            var position = new Position(6, 0);
            IPlayer player = new Player(position);
            player.MoveUp(); // Move up first to test moving down

            // Act
            player.MoveDown();

            // Assert
            Assert.AreEqual(6, position.Row); // Move down should return to the original row
            Assert.AreEqual(0, position.Column); // No change in column
        }

        [TestMethod]
        public void Player_Can_Move_Left()
        {
            // Arrange
            var position = new Position(6, 1);
            IPlayer player = new Player(position);
            player.MoveRight(); // Move right first to test moving left

            // Act
            player.MoveLeft();

            // Assert
            Assert.AreEqual(6, position.Row); // No change in row
            Assert.AreEqual(1, position.Column); // Move left should return to the original column
        }

        [TestMethod]
        public void Player_Can_Move_Right()
        {
            // Arrange
            var position = new Position(6, 1);
            IPlayer player = new Player(position);

            // Act
            player.MoveRight();

            // Assert
            Assert.AreEqual(6, position.Row); // No change in row
            Assert.AreEqual(2, position.Column); // Move right should increase the column
        }
    }
}
