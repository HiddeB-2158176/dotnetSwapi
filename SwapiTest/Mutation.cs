using SwapiTest.Models;
using Microsoft.EntityFrameworkCore;

namespace SwapiTest
{
    public class Mutation
    {
        public async Task<Human> UpdateMassAsync(
            string id, 
            float mass, 
            [Service] SwapiDbContext dbContext)
        {
            var human = await dbContext.Characters.OfType<Human>().FirstOrDefaultAsync(c => c.Id == id);
            if (human == null)
            {
                throw new Exception("Human not found");
            }

            human.Mass = mass;
            await dbContext.SaveChangesAsync();

            return human;
        }

        public async Task<Starship> AddStarshipAsync(
            string id,
            string name, 
            float length, 
            [Service] SwapiDbContext dbContext)
        {
            var starship = new Starship
            {
                Id = id,
                Name = name,
                Length = length
            };

            dbContext.Starships.Add(starship);
            await dbContext.SaveChangesAsync();

            return starship;
        }

        public async Task<Human> AddStarshipToHumanAsync(
            string humanId, 
            string starshipId, 
            [Service] SwapiDbContext dbContext)
        {
            Human human = await dbContext.Characters.OfType<Human>().FirstOrDefaultAsync(c => c.Id == humanId);
            var starship = await dbContext.Starships.FindAsync(starshipId);

            if (human == null || starship == null)
            {
                throw new Exception("Human or Starship not found");
            }

            var starshipIds = human.Starships;
            starshipIds.Add(starship.Id);
            human.Starships = starshipIds; 

            await dbContext.SaveChangesAsync();

            return human;
        }
    }
}
