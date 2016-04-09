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
                string[] command = Console.ReadLine().Split();


                if (command.Length == 1)
                {
                    process = new Process(robot, table, command[0]);
                } else if (command.Length == 2)
                {
                    process = new Process(robot, table, command[0], command[1]);
                } else
                {
                    Console.WriteLine("Command is not valid");
                }
            }
        }
    }
}
