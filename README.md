# Movies Catalog

 1. Clone this repo
 2. Compile
 3. Modify the connectionstring as you want.
 4. Run the solution
 5. Take a look on the endpoints at swagger

You can generate a token, to test the endpoints.


*Seed:
dotnet ef migrations add xxx
dotnet ef database update

## Postman

You can find my postman collection for this challenge here, replace de token variable to use:

https://www.postman.com/caescobar17/workspace/cb-public/collection/6930487-ec128a14-8940-4dbb-8e75-85aedca3c137?action=share&creator=6930487

## Working solution

There is a working API connected to a database here:

https://moviescatalog.azurewebsites.net/swagger/index.html

You can generate a token login with these accounts:

user@gmail.com
admin@gmail.com

pwd: password

## Docker
docker pull caescobar17/moviecatalog_challenge:latest

https://hub.docker.com/r/caescobar17/moviecatalog_challenge/tags
