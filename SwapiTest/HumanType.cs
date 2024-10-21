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

            public IEnumerable<Character> GetFriends([Parent] Human human, [Service] Data data)
            {
                foreach (var friendId in human.Friends)
                {
                    yield return data.GetCharacterById(friendId);
                }
            }

            public IEnumerable<Starship> GetStarships([Parent] Human human, [Service] Data data)
            {
                foreach (var starshipId in human.Starships)
                {
                    yield return data.GetStarshipById(starshipId);
                }
            }
        }
    }
}
