namespace MartianRobots.Domain.Models
{
    public interface IPlanetSurface
    {
        int Height { get; set; }
        int Widht { get; set; }

        void AddLostPoint(Position newPosition);
        bool IsValidPosition(Position newPosition, out bool lost);
    }
}