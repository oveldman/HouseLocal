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
dotnet ef migrations add InitialCreate
```
### Remove Migration
```bash
dotnet ef migrations remove 
```