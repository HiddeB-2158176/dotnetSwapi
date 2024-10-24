using System.Collections.Generic;

namespace SwapiTest.Models
{
    public abstract class Character
    {
        public string Id { get; set;}
        public string Name { get; set;}
        public List<string> Friends { get; set;} = new List<string>(); // Store only Friend IDs
        public List<Episode> AppearsIn { get; set;} = new List<Episode>();
    }
}
