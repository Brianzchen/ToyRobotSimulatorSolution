using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Core
{
    public class Process
    {
        private Command _command;
        private int _xRobotPos;
        private int _yRobotPos;
        private string _robotDirection;

        public Process(Robot robot, SquareTableTop table, string command)
        {
            try
            {
                _command = (Command)Enum.Parse(typeof(Command), command, true);
            } catch(Exception)
            {
                Console.WriteLine("Command is not valid");
                return;
            }
            
            try
            {
                switch (_command)
                {
                    case Command.Place:
                        Console.WriteLine("This command can only be issued with an additional argument in the format 'x,y,direction'");
                        break;
                    case Command.Move:
                        table.ValidateRobotHasBeenPlaced();
                        table.ValidateRobotWillNotFallOffTableTop(_command);
                        robot.Move();
                        break;
                    case Command.Left:
                        table.ValidateRobotHasBeenPlaced();
                        robot.Left();
                        break;
                    case Command.Right:
                        table.ValidateRobotHasBeenPlaced();
                        robot.Right();
                        break;
                    case Command.Report:
                        table.ValidateRobotHasBeenPlaced();
                        Console.WriteLine("The robot is at position: " + robot.XPos + ", " + robot.YPos + " and facing " + robot.Direction);
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }    
        }

        public Process(Robot robot, SquareTableTop table, string command, string input)
        {
            try
            {
                _command = (Command)Enum.Parse(typeof(Command), command, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Command is not valid");
                return;
            }

            try
            {
                if (Convert.ToInt32(_command) == 0)
                {
                    string[] placement = input.Split(',');
                    if (placement.Length == 3)
                    {
                        _xRobotPos = Convert.ToInt32(placement[0]);
                        _yRobotPos = Convert.ToInt32(placement[1]);
                        _robotDirection = placement[2];

                        table.ValidateRobotWillNotFallOffTableTop(_command, _xRobotPos, _yRobotPos);
                        robot.Place(_xRobotPos, _yRobotPos, _robotDirection);
                    }
                    else
                    {
                        Console.WriteLine("Please enter the paramaters as follows: x,y,direction");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }
    }
}
