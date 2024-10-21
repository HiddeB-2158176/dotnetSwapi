using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwapiTest3;
using SwapiTest3.Models;

var builder = WebApplication.CreateBuilder(args);

// Add GraphQL services
builder.Services.AddGraphQLServer()
    .ModifyRequestOptions(opt => opt.IncludeExceptionDetails = true)
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<CharacterType>()
    .AddType<HumanType>()
    .AddType<DroidType>()
    .AddType<StarshipType>()
    .AddType<EpisodeType>();

// Add test data
builder.Services.AddSingleton<Data>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
