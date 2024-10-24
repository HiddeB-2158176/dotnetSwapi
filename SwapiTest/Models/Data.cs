using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SwapiTest.Models
{
    public class Data
    {
        private readonly SwapiDbContext _dbContext;

        public Data(SwapiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Fetch characters based on friendIds
        public async Task<List<Character>> GetFriends(List<string> friendIds)
        {
            return await _dbContext.Characters
                .Where(c => friendIds.Contains(c.Id))
                .ToListAsync();
        }

        // Fetch starships based on starshipIds
        public async Task<List<Starship>> GetStarships(List<string> starshipIds)
        {
            return await _dbContext.Starships
                .Where(s => starshipIds.Contains(s.Id))
                .ToListAsync();
        }
    }
}
