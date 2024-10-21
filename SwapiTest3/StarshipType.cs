using HotChocolate.Types;
using SwapiTest3.Models;

namespace SwapiTest3
{
    public class StarshipType : ObjectType<Starship>
    {
        protected override void Configure(IObjectTypeDescriptor<Starship> descriptor)
        {
            descriptor.Field(s => s.Id).Type<NonNullType<IdType>>();
            descriptor.Field(s => s.Name).Type<NonNullType<StringType>>();
            descriptor.Field(s => s.Length).Type<FloatType>();
        }
    }
}