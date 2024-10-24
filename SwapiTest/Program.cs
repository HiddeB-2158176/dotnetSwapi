using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SwapiTest;
using SwapiTest.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<SwapiDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<Data>();
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
//builder.Services.AddSingleton<Data>();

var app = builder.Build();

app.MapGraphQL();

app.Run();
