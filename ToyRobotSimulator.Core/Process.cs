using System;

namespace ToyRobotSimulator.Core
{
    public class Process
    {
        private Robot _robot;
        private SquareTableTop _table;

        public Process(Robot robot, SquareTableTop table)
        {
            _robot = robot;
            _table = table;
        }

        public void RunSingleCommand(string commandToExecute)
        {
            try
            {
                Command commandEnum = CommandResolver.Resolve(commandToExecute);

                if (commandEnum == Command.Place)
                {
                    throw new ArgumentException("This command can only be issued with an additional argument in the format 'x,y,direction'");
                }

                _table.ValidateRobotHasBeenPlaced();

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

        public void RunPlaceCommand(string commandToExecute, string inputForPlacement)
        {
            try
            {
                Command commandEnum = CommandResolver.Resolve(commandToExecute);

                if (commandEnum != Command.Place) throw new ArgumentException("This is not a valid command");

                string[] placement = inputForPlacement.Split(',');
                if (placement.Length == 3)
                {
                    int xRobotPos = Convert.ToInt32(placement[0]);
                    int yRobotPos = Convert.ToInt32(placement[1]);
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
    }
}
