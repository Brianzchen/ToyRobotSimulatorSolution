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

                string[] commandSplit = readLine.Trim().Split();
                string commandToExecute = commandSplit[0];

                if (commandSplit.Length == 1)
                {
                    process.Simulate(commandToExecute);
                } else if (commandSplit.Length == 2)
                {
                    string input = commandSplit[1];
                    process.Simulate(commandToExecute, input);
                } else
                {
                    Console.WriteLine("Command is not valid");
                }
            }
        }
    }
}
