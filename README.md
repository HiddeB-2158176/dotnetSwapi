DotNet implementation of the Star Wars API using Hot Chocolate.

## Startup instructions
To create and startup the db run the following command in the terminal (make sure docker is running):
"docker run --name swapi-postgres-db -e POSTGRES_PASSWORD=pass123 -e POSTGRES_USER=user -e POSTGRES_DB=swapidb -p 5432:5432 -d postgres"

Then go into the project folder and run the following 2 commands:
1) "dotnet ef migrations add AddCharactersAndStarships"
2) "dotnet ef database update"

After this you should be able to run the project and interact with the database.
