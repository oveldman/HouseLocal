FROM nginx:latest AS base
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["HouseApp.Frontend.UI/HouseApp.Frontend.UI.csproj", "HouseApp.Frontend.UI/"]
RUN dotnet restore "HouseApp.Frontend.UI/HouseApp.Frontend.UI.csproj"
COPY . .
WORKDIR "/src/HouseApp.Frontend.UI"
RUN dotnet build "HouseApp.Frontend.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "HouseApp.Frontend.UI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
COPY --from=publish /app/publish/wwwroot /usr/share/nginx/html
