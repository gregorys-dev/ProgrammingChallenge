# Makefile

migrations-path = ./Src/Infrastructure/
startup-app-path = ./Src/WebApi/
context = ApplicationDbContext
env = Development

add-migration:
	dotnet ef migrations add $(name) -p $(migrations-path) -s $(startup-app-path) --context $(context) -o Persistence/Migrations

apply-migrations:
	dotnet ef database update -p $(migrations-path) -s $(startup-app-path) --context $(context) -o Persistence/Migrations

generate-script:
	dotnet ef migrations script -p $(migrations-path) -s $(startup-app-path) --context $(context) -o Persistence/Migrations

build:
	dotnet build --project $(startup-app-path) --environment=$(env)

run:
	dotnet run --project $(startup-app-path) --environment=$(env)

watch:
	dotnet watch --project $(startup-app-path) run --environment=$(env)

publish-staging: 
	dotnet publish $(startup-app-path) -c=Staging

start-db:
	sudo docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=<YourStrong@Passw0rd>" \
   -p 1433:1433 --name sql1 -h sql1 \
   -d mcr.microsoft.com/mssql/server:2019-latest