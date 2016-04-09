using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Core;

namespace ToyRobotSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            Robot robot = new Robot();
            SquareTableTop table = new SquareTableTop(robot, 5, 5);

            Console.WriteLine("Please begin by placing the robot using the place command");

            if (args.Length > 0)
            {
                // Check if text file exists and run text file
            }

            Process process;

            while (true)
            {
                string[] commandSplit = Console.ReadLine().Split();
                string command = commandSplit[0];

                if (commandSplit.Length == 1)
                {
                    process = new Process(robot, table, command);
                } else if (commandSplit.Length == 2)
                {
                    string input = commandSplit[1];
                    process = new Process(robot, table, command, input);
                } else
                {
                    Console.WriteLine("Command is not valid");
                }
            }
        }
    }
}
