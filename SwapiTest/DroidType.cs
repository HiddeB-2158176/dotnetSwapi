using HotChocolate;
using HotChocolate.Types;
using SwapiTest.Models;
using System.Collections.Generic;

namespace SwapiTest
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
            public async Task<IEnumerable<Character>> GetFriends([Parent] Droid droid, [Service] Data data)
            {
                var friendIds = droid.Friends;
    
                // Use the data service to access the DbContext
                return await data.GetFriends(friendIds);
            }
        }
    }
}
