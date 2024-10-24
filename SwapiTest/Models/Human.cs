using System.Collections.Generic;

namespace SwapiTest.Models
{
    public class Human : Character
    {
        public string HomePlanet { get; set; }
        public List<string> Starships { get; set; } = new List<string>(); // Starship IDs
        public double Mass { get; set; }
    }
}
