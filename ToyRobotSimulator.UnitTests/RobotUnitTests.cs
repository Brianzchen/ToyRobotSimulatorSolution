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
        public void ToyRobotCanBeMovedMoreThanOnce()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 2;
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

            // Act
            robot.Move();

            // Assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos + 2);
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

        [Test]
        public void ToyRobotsFirstValidCommandShouldBePlaceInsteadOfLeft()
        {
            // Arrage
            Robot robot = new Robot();

            // Assert
            Assert.Throws<InvalidOperationException>(() => robot.Left());
        }

        [Test]
        public void ToyRobotsFirstValidCommandShouldBePlaceInsteadOfRight()
        {
            // Arrage
            Robot robot = new Robot();

            // Assert
            Assert.Throws<InvalidOperationException>(() => robot.Right());
        }

        [Test]
        public void ToyRobotsFirstValidCommandShouldBePlaceInsteadOfReport()
        {
            // Arrage
            Robot robot = new Robot();

            // Assert
            Assert.Throws<InvalidOperationException>(() => robot.Report());
        }

        [Test]
        public void ToyRobotShouldBeAbleToBePlacedAfterAlreadyBeingPlaced()
        {
            // Arrange
            const int xPos1 = 2;
            const int yPos1 = 3;
            const int xPos2 = 1;
            const int yPos2 = 1;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos1, yPos1, direction.ToString());

            // Assert
            Assert.AreEqual(robot.XPos, xPos1);
            Assert.AreEqual(robot.YPos, yPos1);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);

            // Act
            robot.Place(xPos2, yPos2, direction.ToString());

            // Assert
            Assert.AreEqual(robot.XPos, xPos2);
            Assert.AreEqual(robot.YPos, yPos2);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void ToyRobotReportMessageReturnsAsExpected()
        {
            // Arrange
            const int xPos = 2;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // Act
            robot.Place(xPos, yPos, direction.ToString());

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 2, 4 and facing North", robot.Report());
        }
    }
}
