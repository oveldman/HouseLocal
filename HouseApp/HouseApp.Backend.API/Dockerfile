FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HouseApp.Backend.API/HouseApp.Backend.API.csproj", "HouseApp.Backend.API/"]
RUN dotnet restore "HouseApp.Backend.API/HouseApp.Backend.API.csproj"
COPY . .
WORKDIR "/src/HouseApp.Backend.API"
RUN dotnet build "HouseApp.Backend.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseApp.Backend.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseApp.Backend.API.dll"]
