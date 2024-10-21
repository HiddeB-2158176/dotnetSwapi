using HotChocolate;
using HotChocolate.Types;
using SwapiTest3.Models;

namespace SwapiTest3
{
    public class Mutation
    {
        public Human UpdateMass(string id, float newMass, [Service] Data data)
        {
            // Retrieve the Human by ID
            var human = data.GetCharacterById(id) as Human;

            if (human == null)
            {
                throw new GraphQLException($"Human with ID {id} not found.");
            }

            // Update the mass
            human.Mass = newMass;

            return human;
        }

        public Starship AddStarship(string id, string name, double length, [Service] Data data)
        {
            // Create a new Starship
            var starship = new Starship
            {
                Id = id,
                Name = name,
                Length = length
            };

            // Add the Starship to the list
            data.Starships.Add(starship);

            return starship;
        }

         public Human AddStarshipToHuman(string humanId, string starshipId, [Service] Data data)
        {
            // Retrieve the Human by ID
            var human = data.GetCharacterById(humanId) as Human;

            if (human == null)
            {
                throw new GraphQLException($"Human with ID {humanId} not found.");
            }

            // Retrieve the Starship by ID
            var starship = data.GetStarshipById(starshipId);

            if (starship == null)
            {
                throw new GraphQLException($"Starship with ID {starshipId} not found.");
            }

            // Check if the starship is already in the list
            if (!human.Starships.Contains(starship.Id))
            {
                // Add the starship ID to the Human's list of starships
                human.Starships.Add(starship.Id);
            }



            return human;  // Return the updated Human object
        }
    }
}
