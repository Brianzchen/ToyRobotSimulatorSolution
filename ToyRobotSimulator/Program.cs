using System;
using System.Linq;
using System.IO;
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

            if (args.Any())
            {
                ProcessArgs(robot, table, process, args);
            }

            while (true)
            {
                string readLine = Console.ReadLine();
                RunCommands(robot, table, process, readLine);
            }
        }

        private static void RunCommands(Robot robot, SquareTableTop table, Process process, string readLine)
        {
            if (readLine == null)
            {
                return;
            }

            string[] commandSplit = readLine.Trim().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (commandSplit.Any())
            {
                string commandToExecute = commandSplit[0];

                if (CommandHasOneArgument(commandSplit))
                {
                    process.RunSingleCommand(commandToExecute);
                }
                else if (CommandHasTwoArguments(commandSplit))
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

        private static void ProcessArgs(Robot robot, SquareTableTop table, Process process, string[] args)
        {
            foreach (string file in args)
            {
                if (File.Exists(@file))
                {
                    ProcessFile(robot, table, process, file);
                }
                else
                {
                    Console.WriteLine("File does not exist");
                }
            }
        }

        private static void ProcessFile(Robot robot, SquareTableTop table, Process process, string file)
        {
            string[] lines = File.ReadAllLines(@file);
            foreach (string line in lines)
            {
                RunCommands(robot, table, process, line);
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

        private static bool CommandHasOneArgument(string[] commandSplit)
        {
            return commandSplit.Length == 1;
        }

        private static bool CommandHasTwoArguments(string[] commandSplit)
        {
            return commandSplit.Length == 2;
        }
    }
}
