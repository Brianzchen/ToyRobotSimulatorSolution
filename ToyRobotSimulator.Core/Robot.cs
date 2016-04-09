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
        private Directions _direction;
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

        public Directions Direction
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
            // Checks if direction value is valid otherwise throw error and return
            try
            {
                _direction = (Directions)Enum.Parse(typeof(Directions), direction, true);
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
                return;
            }

            _xPos = x;
            _yPos = y;
            _placed = true;
        }

        public void Move()
        {
            switch(Convert.ToInt32(_direction))
            {
                case 0:
                    _yPos++;
                    break;
                case 1:
                    _yPos--;
                    break;
                case 2:
                    _xPos++;
                    break;
                case 3:
                    _xPos--;
                    break;
            }
        }

        public void Left()
        {
            switch (Convert.ToInt32(_direction))
            {
                case 0:
                    _direction = Directions.West;
                    break;
                case 1:
                    _direction = Directions.East;
                    break;
                case 2:
                    _direction = Directions.North;
                    break;
                case 3:
                    _direction = Directions.South;
                    break;
            }
        }

        public void Right()
        {
            switch (Convert.ToInt32(_direction))
            {
                case 0:
                    _direction = Directions.East;
                    break;
                case 1:
                    _direction = Directions.West;
                    break;
                case 2:
                    _direction = Directions.South;
                    break;
                case 3:
                    _direction = Directions.North;
                    break;
            }
        }
    }
}
