using NUnit.Framework;
using System;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator.UnitTests
{
    [TestFixture]
    class TableTopUnitTests
    {
        [Test]
        public void TableTopShouldNotBeAbleToCreateWithoutARobot()
        {
            // Arrange
            const int xSize = 5;
            const int ySize = 5;

            // Assert
            Assert.Throws<ArgumentNullException>(() => new SquareTableTop(null, xSize, ySize));
        }

        [Test]
        public void TableTopCannotBeSmallerThanOneUnitWidthAndHeight()
        {
            // Arrange
            const int xSize = -1;
            const int ySize = -1;
            Robot robot = new Robot();

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SquareTableTop(robot, xSize, ySize));
        }

        [Test]
        public void ToyRobotWillNotFallOffTableTopIfOnEdgeOfNorthSide()
        {
            // Arrange
            const int xRobotPos = 3;
            const int yRobotPos = 4;
            const Direction robotDirection = Direction.North;
            const int xTableSize = 5;
            const int yTableSize = 5;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            const Command command = Command.Move;

            // Act
            robot.Place(xRobotPos, yRobotPos, robotDirection.ToString());

            // Assert
            Assert.Throws<InvalidOperationException>(() => table.ValidateMoveRobotWillNotFall(command));
        }

        [Test]
        public void ToyRobotWillNotFallOffTableTopIfOnEdgeOfSouthSide()
        {
            // Arrange
            const int xRobotPos = 1;
            const int yRobotPos = 0;
            const Direction robotDirection = Direction.South;
            const int xTableSize = 5;
            const int yTableSize = 5;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            const Command command = Command.Move;

            // Act
            robot.Place(xRobotPos, yRobotPos, robotDirection.ToString());

            // Assert
            Assert.Throws<InvalidOperationException>(() => table.ValidateMoveRobotWillNotFall(command));
        }

        [Test]
        public void ToyRobotWillNotFallOffTableTopIfOnEdgeOfEastSide()
        {
            // Arrange
            const int xRobotPos = 4;
            const int yRobotPos = 2;
            const Direction robotDirection = Direction.East;
            const int xTableSize = 5;
            const int yTableSize = 5;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            const Command command = Command.Move;

            // Act
            robot.Place(xRobotPos, yRobotPos, robotDirection.ToString());

            // Assert
            Assert.Throws<InvalidOperationException>(() => table.ValidateMoveRobotWillNotFall(command));
        }

        [Test]
        public void ToyRobotWillNotFallOffTableTopIfOnEdgeOfWestSide()
        {
            // Arrange
            const int xRobotPos = 0;
            const int yRobotPos = 3;
            const Direction robotDirection = Direction.West;
            const int xTableSize = 5;
            const int yTableSize = 5;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            const Command command = Command.Move;

            // Act
            robot.Place(xRobotPos, yRobotPos, robotDirection.ToString());

            // Assert
            Assert.Throws<InvalidOperationException>(() => table.ValidateMoveRobotWillNotFall(command));
        }

        [Test]
        public void ToyRobotShouldNotBeAbleToBePlacedPastTheEdgeOfTheTableTop()
        {
            // Arrange
            const int xRobotPos = 6;
            const int yRobotPos = 6;
            const int xTableSize = 5;
            const int yTableSize = 5;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            const Command command = Command.Place;

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => table.ValidatePlacedRobotWillNotFall(command, xRobotPos, yRobotPos));
        }
    }
}
