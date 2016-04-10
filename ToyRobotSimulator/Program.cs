using System;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, 5, 5);
            Process process = new Process(robot, table);

            PrintSimulatorInstructions();

            while (true)
            {
                string readLine = Console.ReadLine();
                if (readLine == null)
                {
                    continue;
                }

                string[] commandSplit = readLine.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (commandSplit.Length > 0)
                {
                    string commandToExecute = commandSplit[0];

                    if (CheckIfCommandHasOneArgument(commandSplit))
                    {
                        process.RunSingleCommand(commandToExecute);
                    }
                    else if (CheckIfCommandHasTwoArguments(commandSplit))
                    {
                        string input = commandSplit[1];
                        process.RunPlaceCommand(commandToExecute, input);
                    }
                    else
                    {
                        Console.WriteLine("Command is not valid");
                    }
                }
            }
        }

        private static void PrintSimulatorInstructions()
        {
            Console.WriteLine("#######################");
            Console.WriteLine("# Robot Toy Simulator Instructions");
            Console.WriteLine("# 1. PLACE 2,3,NORTH to place the robot in position 2, 3 facing north");
            Console.WriteLine("# 2. LEFT to turn the robot left");
            Console.WriteLine("# 3. RIGHT to turn the robot right");
            Console.WriteLine("# 4. MOVE to move the robot one step forward in it\'s direction");
            Console.WriteLine("# 5. REPORT to print the current position of the robot");
            Console.WriteLine("#######################");
        }

        private static bool CheckIfCommandHasOneArgument(string[] commandSplit)
        {
            return commandSplit.Length == 1;
        }

        private static bool CheckIfCommandHasTwoArguments(string[] commandSplit)
        {
            return commandSplit.Length == 2;
        }
    }
}
