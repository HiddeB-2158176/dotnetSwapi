using Microsoft.EntityFrameworkCore;
using SwapiTest.Models;

namespace SwapiTest
{
    public class SwapiDbContext : DbContext
    {
        public SwapiDbContext(DbContextOptions<SwapiDbContext> options) : base(options) { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Starship> Starships { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the primary key for the base class
            modelBuilder.Entity<Character>(c => { c.HasKey(k => k.Id);});
            modelBuilder.Entity<Starship>(s => { s.HasKey(k => k.Id); });

            // Set up TPH for Character, Human, and Droid
            modelBuilder.Entity<Character>()
                .HasDiscriminator<string>("CharacterType")
                .HasValue<Human>("Human")
                .HasValue<Droid>("Droid");

            // Seed data for Humans
            modelBuilder.Entity<Human>().HasData(
                new Human { Id = "1000", Name = "Luke Skywalker", Mass = 77.0, HomePlanet = "Tatooine", AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI }, Friends = new List<string> { "1001", "2000", "2001" }, Starships = new List<string> { "3000", "3001" } },
                new Human { Id = "1001", Name = "Leia Organa", Mass = 55.0, HomePlanet = "Alderaan", AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI }, Friends = new List<string> { "1000" }, Starships = new List<string>() }
            );

            // Seed data for Droids
            modelBuilder.Entity<Droid>().HasData(
                new Droid { Id = "2000", Name = "R2-D2", PrimaryFunction = "Astromech", AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI }, Friends = new List<string> { "1000", "2001" } },
                new Droid { Id = "2001", Name = "C-3PO", PrimaryFunction = "Protocol", AppearsIn = new List<Episode> { Episode.NEWHOPE, Episode.EMPIRE, Episode.JEDI }, Friends = new List<string> { "1000", "2000" } }
            );

            // Seed data for Starships
            modelBuilder.Entity<Starship>().HasData(
                new Starship { Id = "3000", Name = "Millennium Falcon", Length = 34.75 },
                new Starship { Id = "3001", Name = "X-Wing", Length = 12.5 }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
