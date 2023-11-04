FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HouseApp.Backend.Weather/HouseApp.Backend.Weather.csproj", "HouseApp.Backend.Weather/"]
RUN dotnet restore "HouseApp.Backend.Weather/HouseApp.Backend.Weather.csproj"
COPY . .
WORKDIR "/src/HouseApp.Backend.Weather"
RUN dotnet build "HouseApp.Backend.Weather.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseApp.Backend.Weather.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseApp.Backend.Weather.dll"]
