using System;

namespace ToyRobotSimulator.Core
{
    public class Robot
    {
        // Class Variables

        private int _xPos;
        private int _yPos;
        private Direction _direction;
        private bool _placed = false;

        // Class properties

        public int XPos
        {
            get { return _xPos; }
        }

        public int YPos
        {
            get { return _yPos; }
        }

        public Direction Direction
        {
            get { return _direction; }
        }

        public bool IsPlaced
        {
            get { return _placed; }
        }

        // Class Methods
        
        /// <summary>
        /// Places the robot in specified position with direction
        /// </summary>
        public void Place(int x, int y, string direction)
        {
            if (direction == null)
            {
                throw new ArgumentNullException("Direction cannot be null");
            }

            _direction = DirectionResolver.Resolve(direction);

            _xPos = x;
            _yPos = y;
            _placed = true;
        }

        /// <summary>
        /// Moves the robot one unit in the direction it is facing
        /// </summary>
        public void Move()
        {
            CheckIfHasBeenPlaced();

            switch (_direction)
            {
                case Direction.North:
                    _yPos++;
                    break;
                case Direction.South:
                    _yPos--;
                    break;
                case Direction.East:
                    _xPos++;
                    break;
                case Direction.West:
                    _xPos--;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Direction is not valid");
            }
        }

        /// <summary>
        /// Turns the robot 90 degrees left from the direction it was facing
        /// </summary>
        public void Left()
        {
            CheckIfHasBeenPlaced();

            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.West;
                    break;
                case Direction.South:
                    _direction = Direction.East;
                    break;
                case Direction.East:
                    _direction = Direction.North;
                    break;
                case Direction.West:
                    _direction = Direction.South;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Direction is not valid");
            }
        }

        /// <summary>
        /// Turns the robot 90 degrees right from the direction it was facing
        /// </summary>
        public void Right()
        {
            CheckIfHasBeenPlaced();

            switch (_direction)
            {
                case Direction.North:
                    _direction = Direction.East;
                    break;
                case Direction.South:
                    _direction = Direction.West;
                    break;
                case Direction.East:
                    _direction = Direction.South;
                    break;
                case Direction.West:
                    _direction = Direction.North;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Direction is not valid");
            }
        }

        /// <summary>
        /// Returns information of the position of the robot
        /// </summary>
        public string Report()
        {
            CheckIfHasBeenPlaced();

            return "The robot is at position: " + _xPos + ", " + _yPos + " and facing " + _direction;
        }

        private void CheckIfHasBeenPlaced()
        {
            if (_placed == false)
            {
                throw new InvalidOperationException("You cannot perform this operation before the robot has been placed");
            }
        }
    }
}
