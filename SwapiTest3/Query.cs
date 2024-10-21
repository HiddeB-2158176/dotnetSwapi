using System.Collections.Generic;
using SwapiTest3.Models;

namespace SwapiTest3
{
    public class Query
    {
        public IEnumerable<Character> GetCharacters([Service] Data data) => data.Characters;

        public Character GetCharacterById([Service] Data data, string id) =>
            data.GetCharacterById(id);

        public IEnumerable<Starship> GetStarships([Service] Data data) => data.Starships;

        public Starship GetStarshipById([Service] Data data, string id) =>
            data.GetStarshipById(id);

        [GraphQLName("hero")]
        public Character getHero([Service] Data data, Episode episode)
        {
            if (episode == Episode.EMPIRE){
                return data.GetCharacterById("1000");}
            return GetCharacterById(data, "2000");
        }
    }
}
