## To Connect Redis Locally:
	docker run --name local-redis -p 5002:6379 -d redis
## To Connect MongoDB Locally:
    docker run --name mongodb -d -p 27017:27017 mongo
## To Connect SQLite Locally:
    docker run --rm keinos/sqlite3 sqlite3
## To Be Able To Run EF Commands:
    dotnet tool install --global dotnet-ef
## To Create New Migration File:
    dotnet ef --startup-project ../CityLibrary.Graphql migrations add "New_Migration_Name" (run this command in CityLibraryDomain directory)
## To Update Database with Migration Files:
    dotnet ef database update --project CityLibrary.Graphql