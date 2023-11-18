FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HouseApp.Backend.JobRunner/HouseApp.Backend.JobRunner.csproj", "HouseApp.Backend.JobRunner/"]
RUN dotnet restore "HouseApp.Backend.JobRunner/HouseApp.Backend.JobRunner.csproj"
COPY . .
WORKDIR "/src/HouseApp.Backend.JobRunner"
RUN dotnet build "HouseApp.Backend.JobRunner.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseApp.Backend.JobRunner.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseApp.Backend.JobRunner.dll"]
