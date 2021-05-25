using System;
using System.Collections.Generic;

namespace MartianRobots.Domain.Models
{
    public class PlanetSurface : IPlanetSurface
    {
        private const int MAX_X = 50;
        private const int MAX_Y = 50;
        public int Widht { get; set; }
        public int Height { get; set; }

        public List<Position> LostPoints;

        public PlanetSurface(int x, int y)
        {
            if (x > MAX_X || y > MAX_Y)
            {
                throw new ArgumentException("The size is bigger than 50");
            }
            else
            {
                Widht = x;
                Height = y;
                LostPoints = new List<Position>();
            }

        }

        public bool IsValidPosition(Position newPosition, out bool lost)
        {
            if (LostPoints.Contains(newPosition))
            {
                lost = false;
                return false;
            }
            else
            {
                bool validPosition = !(newPosition.X > Widht || newPosition.Y > Height || newPosition.X < 0 || newPosition.Y < 0);

                if (!validPosition)
                {
                    this.AddLostPoint(newPosition);
                    lost = true;
                    return false;
                }
                else
                {
                    lost = false;
                    return true;
                }

            }
        }

        public void AddLostPoint(Position newPosition)
        {
            LostPoints.Add(newPosition);
        }
    }
}
