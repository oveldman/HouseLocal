# Database Readme
## Pre-requisites
```bash
dotnet tool install --global dotnet-ef
# If already installed
dotnet tool update --global dotnet-ef
```
## Migration
### Create Migration
```bash
dotnet ef migrations add InitialCreate --context WeatherDbContext -o ../HouseApp.Backend.Infrastructure/Weathers/Migrations
```
### Remove Migration
```bash
dotnet ef migrations remove 
```