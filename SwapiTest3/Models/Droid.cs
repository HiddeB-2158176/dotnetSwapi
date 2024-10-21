using System.Collections.Generic;

namespace SwapiTest3.Models
{
    public class Droid : Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Friends { get; set; } = new List<string>(); // Friend IDs
        public IEnumerable<Episode> AppearsIn { get; set; } = new List<Episode>();
        public string PrimaryFunction { get; set; }
    }
}
