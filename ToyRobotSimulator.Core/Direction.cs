using System;

namespace ToyRobotSimulator.Core
{
    /// <summary>
    /// All possible directions the robot can face
    /// </summary>
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    /// <summary>
    /// Reused code to validate if input is a valid direction
    /// </summary>
    public static class DirectionResolver
    {
        public static Direction Resolve(string direction)
        {
            Direction directionEnum;
            if (!Enum.TryParse(direction, true, out directionEnum))
            {
                throw new InvalidOperationException("direction is not valid");
            }
            return directionEnum;
        }
    }
}
