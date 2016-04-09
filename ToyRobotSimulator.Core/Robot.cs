using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Place(int x, int y, string direction)
        {
            try
            {
                _direction = (Direction)Enum.Parse(typeof(Direction), direction, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Direction is not valid");
            }

            _xPos = x;
            _yPos = y;
            _placed = true;
        }

        public void Move()
        {
            switch(_direction)
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
            }
        }

        public void Left()
        {
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
            }
        }

        public void Right()
        {
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
            }
        }
    }
}
