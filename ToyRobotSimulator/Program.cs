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

            Console.WriteLine("Please begin by placing the robot using the place command");

            if (args.Length > 0)
            {
                // Check if text file exists and run text file
            }



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
