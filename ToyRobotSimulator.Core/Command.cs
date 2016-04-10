using System;

namespace ToyRobotSimulator.Core
{
    public enum Command
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }

    public static class CommandResolver
    {
        public static Command Resolve(string commandToExecute)
        {
            Command commandEnum;
            if (!Enum.TryParse(commandToExecute, true, out commandEnum))
            {
                throw new InvalidOperationException("Command is not valid");
            }
            return commandEnum;
        }
    }
}
