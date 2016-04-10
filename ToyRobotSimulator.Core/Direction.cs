using System;

namespace ToyRobotSimulator.Core
{
    public enum Direction
    {
        North,
        South,
        East,
        West
    }

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
