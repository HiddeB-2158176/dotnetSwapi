using System.Collections.Generic;
using System.Linq;

namespace SwapiTest.Models
{
    public class Data
    {
        public List<Character> Characters { get; set; } = new List<Character>();
        public List<Starship> Starships { get; set; } = new List<Starship>();

        public Data()
        {
            var millenniumFalcon = new Starship { Id = "1", Name = "Millennium Falcon", Length = 34.37 };
            var xWing = new Starship { Id = "2", Name = "X-Wing", Length = 12.5 };

            Starships.Add(millenniumFalcon);
            Starships.Add(xWing);

            var luke = new Human
            {
                Id = "1000",
                Name = "Luke Skywalker",
                HomePlanet = "Tatooine",
                Mass = 77,
                AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI },
                Starships = new List<string> { millenniumFalcon.Id, xWing.Id },
                Friends = new List<string> { "1001", "2000" } // Leia, C-3PO
            };

            var leia = new Human
            {
                Id = "1001",
                Name = "Leia Organa",
                HomePlanet = "Alderaan",
                Mass = 75,
                AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI },
                Starships = new List<string>(),
                Friends = new List<string> { "1000" } // Luke
            };

            var c3po = new Droid
            {
                Id = "2000",
                Name = "C-3PO",
                PrimaryFunction = "Protocol",
                AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI },
                Friends = new List<string> { "1000", "2001" } // Luke, R2-D2
            };

            var r2d2 = new Droid
            {
                Id = "2001",
                Name = "R2-D2",
                PrimaryFunction = "Astromech",
                AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI },
                Friends = new List<string> { "2000" } // C-3PO
            };

            Characters.Add(luke);
            Characters.Add(leia);
            Characters.Add(c3po);
            Characters.Add(r2d2);
        }

        public Character GetCharacterById(string id)
        {
            return Characters.FirstOrDefault(c => c.Id == id);
        }

        public Starship GetStarshipById(string id)
        {
            return Starships.FirstOrDefault(s => s.Id == id);
        }
    }
}
