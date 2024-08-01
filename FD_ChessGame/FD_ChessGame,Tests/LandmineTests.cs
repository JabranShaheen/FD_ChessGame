using Microsoft.VisualStudio.TestTools.UnitTesting;
using FD_ChessGame.Implementations;
using FD_ChessGame.Abstractions;

namespace FD_ChessGame.Tests
{
    [TestClass]
    public class LandmineTests
    {

        [TestMethod]
        public void Landmine_Identifies_Correct_Position()
        {
            // Arrange
            var landminePosition = new Position(5, 5);
            var landmine = new Landmine(landminePosition);
            var testPosition = new Position(5, 5);

            // Act
            var isAtPosition = landmine.IsAtPosition(testPosition);

            // Assert
            Assert.IsTrue(isAtPosition);
        }
    }
}
