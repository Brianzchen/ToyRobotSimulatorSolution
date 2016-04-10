using NUnit.Framework;
using System;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator.UnitTests
{
    [TestFixture]
    public class UnitTests
    {
        [Test]
        public void PlaceToyRobotShouldBeInTheSpecifiedPosition()
        {
            // arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // act
            robot.Place(xPos, yPos, direction.ToString());

            // assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, xPos);
            Assert.AreEqual(robot.Direction, direction);
            Assert.IsTrue(robot.IsPlaced);
        }

        [Test]
        public void PlaceToyRobotWithInvalidDirectionShouldDoIgnoreCommand()
        {
            // arrange
            const int xPos = 2;
            const int yPos = 3;
            const string direction = "direction";
            Robot robot = new Robot();

            // act
            robot.Place(xPos, yPos, direction);

            // assert
            Assert.AreEqual(robot.XPos, 0);
            Assert.AreEqual(robot.YPos, 0);
            Assert.AreEqual(robot.Direction, Direction.North);
            Assert.IsFalse(robot.IsPlaced);
        }

        [Test]
        public void FirstValidCommandMustBePlace()
        {
            // arrange
            Robot robot = new Robot();

            // act
            robot.Move();

            // assert

        }

        [Test]
        public void ToyRobotMoveWillMoveTheRobotOneUnitInTheDirectionItIsFacing()
        {
            // arrange
            const int xPos = 2;
            const int yPos = 3;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Move();

            // assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos + 1);
            Assert.AreEqual(robot.Direction, direction);
        }

        [Test]
        public void ToyRobotMoveShouldNotMoveForwardIfItWillFall()
        {
            // arrange
            const int xPos = 2;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Move();

            // assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, direction);
        }

        [Test]
        public void ToyRobotCanTurnLeftWithoutItsPositionChanging()
        {
            // arrange
            const int xPos = 2;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Left();

            // assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, Direction.West);
        }

        [Test]
        public void ToyRobotCanTurnRightWithoutItsPositionChanging()
        {
            // arrange
            const int xPos = 2;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();

            // act
            robot.Place(xPos, yPos, direction.ToString());
            robot.Right();

            // assert
            Assert.AreEqual(robot.XPos, xPos);
            Assert.AreEqual(robot.YPos, yPos);
            Assert.AreEqual(robot.Direction, Direction.East);
        }

        [Test]
        public void ToyRobotShouldNotBeAbleToBePlacedOutOfTableBounds()
        {
            // arrange
            const int xPos = 6;
            const int yPos = 4;
            const Direction direction = Direction.North;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, 5, 5);

            // act
            robot.Place(xPos, yPos, direction.ToString());

            // assert
        }
    }
}
