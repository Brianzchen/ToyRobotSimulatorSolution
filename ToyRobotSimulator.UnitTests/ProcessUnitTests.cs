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

        [Test]
        public void ProcessScenarioTest1()
        {
            // Arrange
            const int xRobotPos = 1;
            const int yRobotPos = 2;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction = Direction.South;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{xRobotPos},{yRobotPos},{direction}");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("RIGHT");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("REPORT");

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 1, 0 and facing South", robot.Report());
        }

        [Test]
        public void ProcessScenarioTest2()
        {
            // Arrange
            const int xRobotPos = 2;
            const int yRobotPos = 0;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction = Direction.North;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{-xRobotPos},{yRobotPos},{direction}");
            process.RunPlaceCommand("PLACE", $"{xRobotPos},{yRobotPos},{direction}");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("RIGHT");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("RIGHT");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("RIGHT");
            process.RunSingleCommand("REPORT");

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 4, 0 and facing West", robot.Report());
        }

        [Test]
        public void ProcessScenarioTest3()
        {
            // Arrange
            const int xRobotPos1 = 1;
            const int yRobotPos1 = 1;
            const int xRobotPos2 = 2;
            const int yRobotPos2 = 3;
            const int xRobotPos3 = 4;
            const int yRobotPos3 = 4;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction1 = Direction.South;
            const Direction direction2 = Direction.North;
            const Direction direction3 = Direction.East;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{xRobotPos1},{yRobotPos1},{direction1}");
            process.RunPlaceCommand("PLACE", $"{xRobotPos2},{yRobotPos2},{direction2}");
            process.RunSingleCommand("LEFT");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunPlaceCommand("PLACE", $"{xRobotPos3},{yRobotPos3},{direction3}");
            process.RunSingleCommand("REPORT");

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 4, 4 and facing East", robot.Report());
        }

        [Test]
        public void ProcessScenarioTest4()
        {
            // Arrange
            const int xRobotPos1 = 1;
            const int yRobotPos1 = 1;
            const int xRobotPos2 = 2;
            const int yRobotPos2 = 4;
            const int xTableSize = 5;
            const int yTableSize = 5;
            const Direction direction1 = Direction.West;
            const Direction direction2 = Direction.South;
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, xTableSize, yTableSize);
            Process process = new Process(robot, table);

            // Act
            process.RunPlaceCommand("PLACE", $"{xRobotPos1},{yRobotPos1},{direction1}");
            process.RunPlaceCommand("MOVE", $"{xRobotPos2},{yRobotPos2},{direction2}");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("MOVE");
            process.RunSingleCommand("REPORT");

            // Assert
            StringAssert.AreEqualIgnoringCase("The robot is at position: 0, 1 and facing West", robot.Report());
        }
    }
}
