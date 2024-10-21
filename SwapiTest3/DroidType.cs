using HotChocolate;
using HotChocolate.Types;
using SwapiTest3.Models;
using System.Collections.Generic;

namespace SwapiTest3
{
    public class DroidType : ObjectType<Droid>
    {
        protected override void Configure(IObjectTypeDescriptor<Droid> descriptor)
        {
            descriptor.Implements<CharacterType>();       

            descriptor.Field(c => c.PrimaryFunction).Type<StringType>();
            //descriptor.Field(d => d.Friends).Type<ListType<StringType>>();

            descriptor.Field(c => c.Friends)
                .Name("friends")  // Rename field to "friends"
                .Type<ListType<CharacterType>>()  // Return a list of Characters
                .ResolveWith<DroidResolvers>(r => r.GetFriends(default, default));
        }

        public class DroidResolvers
        {
            public IEnumerable<Character> GetFriends([Parent] Droid droid, [Service] Data data)
            {
                // Resolve friend IDs to Character objects
                foreach (var friendId in droid.Friends)
                {
                    yield return data.GetCharacterById(friendId);
                }
            }
        }
    }
}
