using NUnit.Framework;
using System;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator.UnitTests
{
    [TestFixture]
    class RobotUnitTests
    {
        [Test]
        public void ToyRobotCanBePlacedOnTableTopInSpecifiedPosition()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());

            // Assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void ToyRobotCannotBePlacedWithInvalidDirection()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 3;
            const string direction = "FakeDirection";
            Robot robot = new Robot();

            // Assert
            Assert.Throws<InvalidOperationException>(() => robot.Place(xPos, yPos, direction));
        }

        [Test]
        public void ToyRobotCanMoveInDirectionItIsFacingByOneUnitIfFacingNorth()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Move();

            // Assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos + 1);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void ToyRobotCanMoveInDirectionItIsFacingByOneUnitIfFacingSouth()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.South;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Move();

            // Assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos - 1);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void ToyRobotCanMoveInDirectionItIsFacingByOneUnitIfFacingEast()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.East;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Move();

            // Assert
            Assert.AreEqual(robot.XPos, xPos + 1);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void ToyRobotCanMoveInDirectionItIsFacingByOneUnitIfFacingWest()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.West;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Move();

            // Assert
            Assert.AreEqual(robot.XPos, xPos - 1);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void ToyRobotCanTurnLeftWithoutChangingPosition()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Left();

            // Assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, Direction.West);
        }

        [Test]
        public void ToyRobotCanTurnRightWithoutChangingPosition()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Right();

            // Assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, Direction.East);
        }

        [Test]
        public void ToyRobotsFirstValidCommandShouldBePlaceInsteadOfMove()
        {
            // Arrage
            Robot robot = new Robot();

            // Assert
            Assert.Throws<InvalidOperationException>(() => robot.Move());
        }
    }
}
