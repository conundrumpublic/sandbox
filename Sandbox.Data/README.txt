create the docker container
docker pull mcr.microsoft.com/mssql/server:2022-latest
docker create --name sandbox -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=password123!' -p 1432:1433 <containerid>
docker start sandbox

run dotnet ef database update

run the services and frontend, have fun