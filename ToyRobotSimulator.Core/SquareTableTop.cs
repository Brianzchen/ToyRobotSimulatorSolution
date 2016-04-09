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

            _robot = robot;
            _xSize = xSize-1;
            _ySize = ySize-1;
        }

        public void ValidateRobotWillNotFallOffTableTop(Commands command)
        {
            if (command == Commands.Move)
            {
                switch(Convert.ToInt32(_robot.Direction))
                {
                    case 0:
                        if (_robot.YPos == _ySize)
                        {
                            Console.WriteLine("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further North, please turn the robot or place it at a new location");
                            throw new InvalidOperationException("You cannot move the robot any further");
                        }
                        break;
                    case 1:
                        if (_robot.YPos == 0)
                        {
                            Console.WriteLine("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further South, please turn the robot or place it at a new location");
                            throw new InvalidOperationException("You cannot move the robot any further");
                        }
                        break;
                    case 2:
                        if (_robot.XPos == _xSize)
                        {
                            Console.WriteLine("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further East, please turn the robot or place it at a new location");
                            throw new InvalidOperationException("You cannot move the robot any further");
                        }
                        break;
                    case 3:
                        if (_robot.XPos == 0)
                        {
                            Console.WriteLine("The robot is at " + _robot.XPos + ", " + _robot.YPos + " and connot move further West, please turn the robot or place it at a new location");
                            throw new InvalidOperationException("You cannot move the robot any further");
                        }
                        break;
                }
            }
        }

        public void ValidateRobotWillNotFallOffTableTop(Commands command, int xRobotPos, int yRobotPos)
        {
            if (command == Commands.Place)
            {
                if (xRobotPos > _xSize || xRobotPos < 0)
                {
                    Console.WriteLine("Your x position is out of bounds, please select an x value between, 0 and " + _xSize);
                    throw new ArgumentOutOfRangeException("x value out of range");
                }

                if (yRobotPos > _ySize || yRobotPos < 0)
                {
                    Console.WriteLine("Your y position is out of bounds, please select a y value between, 0 and " + _ySize);
                    throw new ArgumentOutOfRangeException("y value out of range");
                }
            }
        }

        public void ValidateRobotHasBeenPlaced()
        {
            if (_robot.IsPlaced == false)
            {
                Console.WriteLine("Please use the place command to place the robot before you can access other commands");
                throw new Exception("Robot has not been placed yet");
            }
        }
    }
}
