using System;

namespace ToyRobotSimulator.Core
{
    public class Process
    {
        // Class Variables

        private Robot _robot;
        private SquareTableTop _table;

        // Class Constructor

        /// <summary>
        /// Creates a process object to handle commands
        /// </summary>
        public Process(Robot robot, SquareTableTop table)
        {
            if (robot == null && table == null)
            {
                throw new ArgumentNullException("Robot and table cannot be null");
            }

            _robot = robot;
            _table = table;
        }

        // Class Methods

        /// <summary>
        /// Runs all one argument commands
        /// </summary>
        public void RunSingleCommand(string commandToExecute)
        {
            try
            {
                Command commandEnum = CommandResolver.Resolve(commandToExecute);

                if (commandEnum == Command.Place)
                {
                    throw new ArgumentException("This command can only be issued with an additional argument in the format 'x,y,direction'");
                }

                switch (commandEnum)
                {
                    case Command.Move:
                        _table.ValidateMoveRobotWillNotFall(commandEnum);
                        _robot.Move();
                        break;
                    case Command.Left:
                        _robot.Left();
                        break;
                    case Command.Right:
                        _robot.Right();
                        break;
                    case Command.Report:
                        Console.WriteLine(_robot.Report());
                        break;
                    default:
                        throw new ArgumentException("This is not a valid command");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Runs only the place command
        /// </summary>
        public void RunPlaceCommand(string commandToExecute, string inputForPlacement)
        {
            try
            {
                Command commandEnum = CommandResolver.Resolve(commandToExecute);

                if (commandEnum != Command.Place) throw new ArgumentException("This is not a valid command");

                string[] placement = inputForPlacement.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
                if (ValidateHasThreeInputs(placement))
                {
                    int xRobotPos = TryConvertValueToInt(placement[0], "x");
                    int yRobotPos = TryConvertValueToInt(placement[1], "y");
                    string robotDirection = placement[2];

                    _table.ValidatePlacedRobotWillNotFall(commandEnum, xRobotPos, yRobotPos);
                    _robot.Place(xRobotPos, yRobotPos, robotDirection);
                }
                else
                {
                    throw new ArgumentException("Please enter the paramaters as follows: x,y,direction");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static bool ValidateHasThreeInputs(string[] placement)
        {
            return placement.Length == 3;
        }

        private static int TryConvertValueToInt(string value, string coord)
        {
            try
            {
                int result = Convert.ToInt32(value);

                return result;
            }
            catch (Exception)
            {
                throw new InvalidCastException($"The value you have entered for {coord} is not a number and cannot be processed");
            }
        }
    }
}
