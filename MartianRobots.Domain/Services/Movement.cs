using MartianRobots.Domain.Models;

namespace MartianRobots.Domain
{
    public enum Instructions
    {
        Left = 'L',
        Right = 'R',
        Forward = 'F'

    }
    public class Movement : IMovement
    {
        private readonly Robot _robot;
        private readonly Instructions _instruction;
        private readonly IPlanetSurface _surface;
        private Position newPosition;
        private Position lastPosition;
        public Movement(Instructions instruction, Robot robot, IPlanetSurface surface)
        {
            _robot = robot;
            _instruction = instruction;
            _surface = surface;
        }

        public bool ExecuteMovement()
        {
            newPosition = new Position(_robot.Position.X, _robot.Position.Y, _robot.Position.Orientation, _robot.Position.Instruction);
            lastPosition = new Position(_robot.Position.X, _robot.Position.Y, _robot.Position.Orientation, _robot.Position.Instruction);
            newPosition.Instruction = _instruction;

            switch (_instruction)
            {
                case Instructions.Forward:
                    ForwardMovement();
                    break;
                case Instructions.Left:
                    LeftMovement();
                    break;
                case Instructions.Right:
                    RightMovement();
                    break;
            }
            bool validPosition = _surface.IsValidPosition(newPosition, out bool lost);
            if (validPosition)
            {
                _robot.Position = newPosition;
            }
            _robot.IsLost = lost;
            return lost;
        }
        private void LeftMovement()
        {
            switch (lastPosition.Orientation)
            {
                case Orientation.East:
                    newPosition.Orientation = Orientation.North;
                    break;
                case Orientation.West:
                    newPosition.Orientation = Orientation.South;
                    break;
                case Orientation.South:
                    newPosition.Orientation = Orientation.East;
                    break;
                case Orientation.North:
                    newPosition.Orientation = Orientation.West;
                    break;
            }
        }

        private void RightMovement()
        {
            switch (lastPosition.Orientation)
            {
                case Orientation.East:
                    newPosition.Orientation = Orientation.South;
                    break;
                case Orientation.West:
                    newPosition.Orientation = Orientation.North;
                    break;
                case Orientation.South:
                    newPosition.Orientation = Orientation.West;
                    break;
                case Orientation.North:
                    newPosition.Orientation = Orientation.East;
                    break;
            }
        }

        private void ForwardMovement()
        {
            switch (lastPosition.Orientation)
            {
                case Orientation.East:
                    newPosition.X++;
                    break;
                case Orientation.West:
                    newPosition.X--;
                    break;
                case Orientation.South:
                    newPosition.Y--;
                    break;
                case Orientation.North:
                    newPosition.Y++;
                    break;
            }
        }
    }
}
