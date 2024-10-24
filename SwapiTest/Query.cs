using HotChocolate;
using Microsoft.EntityFrameworkCore;
using SwapiTest.Models;

namespace SwapiTest
{
    public class Query
    {
        public async Task<List<Character>> GetCharacters([Service] SwapiDbContext dbContext){
            return await dbContext.Characters.ToListAsync();
        }

        public async Task<Character> GetCharacterById([Service] SwapiDbContext dbContext, string id){
            return await dbContext.Characters.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Starship>> GetStarships([Service] SwapiDbContext dbContext){
            return await dbContext.Starships.ToListAsync();
        }

        public async Task<Starship> GetStarshipById([Service] SwapiDbContext dbContext, string id){
            return await dbContext.Starships.FirstOrDefaultAsync(s => s.Id == id);
        }


        [GraphQLName("hero")]
        public async Task<Character> GetHero(Episode episode, [Service] SwapiDbContext dbContext)
        {
            if (episode == Episode.EMPIRE)
            {
                return await dbContext.Characters.FirstOrDefaultAsync(c => c.Id == "1000");
            }

            // Otherwise, return the character with ID "2001"
            return await dbContext.Characters.FirstOrDefaultAsync(c => c.Id == "2001");
        }
    }
}
