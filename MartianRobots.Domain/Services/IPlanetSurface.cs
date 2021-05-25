namespace MartianRobots.Domain.Models
{
    public interface IPlanetSurface
    {


        void AddLostPoint(Position newPosition);
        bool IsValidPosition(Position newPosition, out bool lost);
    }
}