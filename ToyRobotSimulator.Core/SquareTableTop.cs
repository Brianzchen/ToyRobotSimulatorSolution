using System;

namespace ToyRobotSimulator.Core
{
    public class SquareTableTop
    {
        // Class Variables

        private readonly Robot _robot;
        private readonly int _xSize;
        private readonly int _ySize;

        // Class Constructor

        /// <summary>
        /// Creates the tabletop that will restrict the robot
        /// </summary>
        public SquareTableTop(Robot robot, int xSize, int ySize)
        {
            if (robot == null)
            {
                throw new ArgumentNullException("robot cannot be null");
            }

            if (xSize <= 0 || ySize <= 0)
            {
                throw new ArgumentOutOfRangeException("X and y values must be set greater than zero");
            }

            _robot = robot;
            _xSize = xSize;
            _ySize = ySize;
        }

        // Class Methods

        /// <summary>
        /// Validates the robot will not fall of the table when it moves
        /// </summary>
        public void ValidateMoveRobotWillNotFall(Command command)
        {
            if (command != Command.Move) throw new ArgumentException($"You cannot perform this function with the command, {command.ToString()}");

            ValidateRobotCanMoveNorth();
            ValidateRobotCanMoveSouth();
            ValidateRobotCanMoveEast();
            ValidateRobotCanMoveWest();
        }

        /// <summary>
        /// Validates the robot will not fall to its doom when it it placed down
        /// </summary>
        public void ValidatePlacedRobotWillNotFall(Command command, int xRobotPos, int yRobotPos)
        {
            if (command != Command.Place) throw new InvalidOperationException("This is not a valid command, only the place command may take 2 arguments");

            if (xRobotPos >= _xSize || xRobotPos < 0)
            {
                throw new ArgumentOutOfRangeException($"Your x position is out of bounds, please select an x value between, 0 and {_xSize - 1}");
            }

            if (yRobotPos >= _ySize || yRobotPos < 0)
            {
                throw new ArgumentOutOfRangeException($"Your y position is out of bounds, please select a y value between, 0 and {_ySize - 1}");
            }
        }

        private void ThrowDirectionException(Direction direction)
        {
            throw new InvalidOperationException($"The robot is at {_robot.XPos}, {_robot.YPos} and connot move further {_robot.Direction}, please turn the robot or place it at a new location");
        }

        private void ValidateRobotCanMoveNorth()
        {
            if (_robot.Direction != Direction.North) return;

            if (_robot.YPos + 1 >= _ySize)
            {
                ThrowDirectionException(Direction.North);
            }
        }

        private void ValidateRobotCanMoveSouth()
        {
            if (_robot.Direction != Direction.South) return;

            if (_robot.YPos - 1 < 0)
            {
                ThrowDirectionException(Direction.South);
            }
        }

        private void ValidateRobotCanMoveEast()
        {
            if (_robot.Direction != Direction.East) return;

            if (_robot.XPos + 1 >= _xSize)
            {
                ThrowDirectionException(Direction.East);
            }
        }

        private void ValidateRobotCanMoveWest()
        {
            if (_robot.Direction != Direction.West) return;

            if (_robot.XPos - 1 < 0)
            {
                ThrowDirectionException(Direction.West);
            }
        }
    }
}
