using System;
using System.Diagnostics.CodeAnalysis;

namespace MartianRobots.Domain.Models
{
    [ExcludeFromCodeCoverage]

    public class Position : IEquatable<Position>
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Orientation? Orientation { get; set; }
        public Instructions? Instruction { get; set; }

        public Position(int x, int y, Orientation? orientation, Instructions? instruction)
        {
            this.X = x;
            this.Y = y;
            this.Orientation = orientation;
            this.Instruction = instruction;
        }

        bool IEquatable<Position>.Equals(Position other)
        {
            return this.X == other.X &&
              this.Y == other.Y &&
              this.Orientation == other.Orientation &&
              this.Instruction == other.Instruction;
        }
    }
}
