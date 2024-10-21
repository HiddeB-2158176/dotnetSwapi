using System.Collections.Generic;

namespace SwapiTest.Models
{
    public interface Character
    {
        string Id { get; }
        string Name { get; }
        IEnumerable<string> Friends { get; } // Store only Friend IDs
        IEnumerable<Episode> AppearsIn { get; }
    }
}
