FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["HouseApp.Backend.FormulaOne/HouseApp.Backend.FormulaOne.csproj", "HouseApp.Backend.FormulaOne/"]
RUN dotnet restore "HouseApp.Backend.FormulaOne/HouseApp.Backend.FormulaOne.csproj"
COPY . .
WORKDIR "/src/HouseApp.Backend.FormulaOne"
RUN dotnet build "HouseApp.Backend.FormulaOne.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseApp.Backend.FormulaOne.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "HouseApp.Backend.FormulaOne.dll"]
