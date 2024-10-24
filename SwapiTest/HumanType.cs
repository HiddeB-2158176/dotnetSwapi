using HotChocolate.Types;
using SwapiTest.Models;

namespace SwapiTest
{
    public class HumanType : ObjectType<Human>
    {
        protected override void Configure(IObjectTypeDescriptor<Human> descriptor)
        {
            descriptor.Implements<CharacterType>();
            
            descriptor.Field(h => h.Mass).Type<FloatType>();
            descriptor.Field(h => h.HomePlanet).Type<StringType>();
            //descriptor.Field(h => h.Friends).Type<ListType<StringType>>();
            //descriptor.Field(h => h.Starships).Type<ListType<StringType>>();
            
            
            descriptor.Field(h => h.Friends)
                .Name("friends")  // Rename field to "friends"
                .Type<ListType<CharacterType>>()  // Define friends as a list of Character objects
                .ResolveWith<HumanResolvers>(r => r.GetFriends(default, default));

            descriptor.Field(h => h.Starships)
                .Name("starships")  // Rename field to "starships"
                .Type<ListType<StarshipType>>()  // Define starships as a list of Starship objects
                .ResolveWith<HumanResolvers>(r => r.GetStarships(default, default)); // Pass only Human to resolver
            
        }

        public class HumanResolvers
    {
        // Resolves the friends for a human character
        public async Task<IEnumerable<Character>> GetFriends([Parent] Human human, [Service] Data data)
        {
            var friendIds = human.Friends;

            // Use the data service to access the DbContext
            return await data.GetFriends(friendIds);
        }

        // Resolves the starships for a human character
        public async Task<IEnumerable<Starship>> GetStarships([Parent] Human human, [Service] Data data)
        {
            var starshipIds = human.Starships;

            // Use the data service to access the DbContext
            return await data.GetStarships(starshipIds);
        }
    }
    }
}
