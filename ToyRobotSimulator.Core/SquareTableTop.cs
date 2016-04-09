using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core
{
    public class SquareTableTop
    {
        private readonly Robot _robot;
        private readonly int _xSize;
        private readonly int _ySize;

        public SquareTableTop(Robot robot, int xSize, int ySize)
        {
            if (robot == null) {
                throw new ArgumentNullException("robot cannot be null");
            }

            if (xSize <=0 || ySize <=0)
            {
                throw new ArgumentOutOfRangeException("X and y values must be set greater than zero");
            }

            _robot = robot;
            _xSize = xSize;
            _ySize = ySize;
        }

        public void ValidateRobotWillNotFallOffTableTop(Command command)
        {
            if (command == Command.Move)
            {
                switch(_robot.Direction)
                {
                    case Direction.North:
                        if (_robot.YPos+1 >= _ySize)
                        {
                            throw new InvalidOperationException("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further North, please turn the robot or place it at a new location");
                        }
                        break;
                    case Direction.South:
                        if (_robot.YPos-1 < 0)
                        {
                            throw new InvalidOperationException("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further South, please turn the robot or place it at a new location");
                        }
                        break;
                    case Direction.East:
                        if (_robot.XPos+1 >= _xSize)
                        {
                            throw new InvalidOperationException("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further East, please turn the robot or place it at a new location");
                        }
                        break;
                    case Direction.West:
                        if (_robot.XPos-1 < 0)
                        {
                            throw new InvalidOperationException("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further West, please turn the robot or place it at a new location");
                        }
                        break;
                }
            }
        }

        public void ValidateRobotWillNotFallOffTableTop(Command command, int xRobotPos, int yRobotPos)
        {
            if (command == Command.Place)
            {
                if (xRobotPos >= _xSize || xRobotPos < 0)
                {
                    throw new ArgumentOutOfRangeException("Your x position is out of bounds, please select an x value between, 0 and " + (_xSize-1));
                }

                if (yRobotPos >= _ySize || yRobotPos < 0)
                {
                    throw new ArgumentOutOfRangeException("Your y position is out of bounds, please select a y value between, 0 and " + (_ySize-1));
                }
            }
        }

        public void ValidateRobotHasBeenPlaced()
        {
            if (_robot.IsPlaced == false)
            {
                throw new Exception("Please use the place command to place the robot before you can access other commands");
            }
        }
    }
}
