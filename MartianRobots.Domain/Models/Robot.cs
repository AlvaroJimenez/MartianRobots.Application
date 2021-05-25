using System.Diagnostics.CodeAnalysis;

namespace MartianRobots.Domain.Models
{
    [ExcludeFromCodeCoverage]
    public class Robot
    {
        public Position Position { get; set; }
        public bool IsLost { get; set; }

    }
}
