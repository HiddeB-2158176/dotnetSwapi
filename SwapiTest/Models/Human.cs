using System.Collections.Generic;

namespace SwapiTest.Models
{
    public class Human : Character
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Friends { get; set; } = new List<string>(); // Friend IDs
        public IEnumerable<Episode> AppearsIn { get; set; } = new List<Episode>();
        public string HomePlanet { get; set; }
        public List<string> Starships { get; set; } = new List<string>(); // Starship IDs
        public double Mass { get; set; }

        /*public IEnumerable<Starship> test([Parent] Human human, [Service] Data data)
            {
                foreach (var starshipId in human.Starships)
                {
                    yield return data.GetStarshipById(starshipId);
                }
            }*/
    }
}
