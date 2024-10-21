using HotChocolate.Types;
using SwapiTest3.Models;

namespace SwapiTest3
{
    public class CharacterType : InterfaceType<Character>
    {
        protected override void Configure(IInterfaceTypeDescriptor<Character> descriptor)
        {
            descriptor.Field(c => c.Id).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.Name).Type<NonNullType<StringType>>();
            descriptor.Field(c => c.AppearsIn).Type<ListType<EpisodeType>>();
            
            // Resolve friends as a list of Character objects instead of strings (IDs)
            descriptor.Field(c => c.Friends).Type<ListType<CharacterType>>();     
        }

        private class CharacterResolvers
        {
            /*public IEnumerable<Character> GetFriends([Parent] Character character, [Service] Data data)
            {
                foreach (var friendId in character.Friends)
                {
                    yield return data.GetCharacterById(friendId);  // Resolve each friend by ID
                }
            }*/
        }
    }
}
