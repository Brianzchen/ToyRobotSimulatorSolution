using System;

namespace ToyRobotSimulator.Core
{
    /// <summary>
    /// All possible robot commands
    /// </summary>
    public enum Command
    {
        Place,
        Move,
        Left,
        Right,
        Report
    }

    /// <summary>
    /// Reused code to validate if input is a real command
    /// </summary>
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
