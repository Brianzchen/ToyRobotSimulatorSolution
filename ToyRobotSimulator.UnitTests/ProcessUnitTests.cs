using NUnit.Framework;
using ToyRobotSimulator.Core;
using System;


namespace ToyRobotSimulator.UnitTests
{
    [TestFixture]
    class ProcessUnitTests
    {
        [Test]
        public void ProcessScenarioTestA()
        {
            // Arrange
            const int xRobotPos = 0;
            const int yRobotPos = 0;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction = Direction.North;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{xRobotPos},{yRobotPos},{direction}");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("REPORT");

            // Assert
            Assert.That("The robot is at position: 0, 1 and facing North", Is.EqualTo(robot.Report()));
        }

        [Test]
        public void ProcessScenarioTestB()
        {
            // Arrange
            const int xRobotPos = 0;
            const int yRobotPos = 0;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction = Direction.North;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{xRobotPos},{yRobotPos},{direction}");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("REPORT");

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 0, 0 and facing WEST", robot.Report());
        }

        [Test]
        public void ProcessScenarioTestC()
        {
            // Arrange
            const int xRobotPos = 1;
            const int yRobotPos = 2;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction = Direction.East;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{xRobotPos},{yRobotPos},{direction}");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("REPORT");

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 3, 3 and facing North", robot.Report());
        }
    }
}
