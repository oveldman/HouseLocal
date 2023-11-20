using HouseApp.Backend.Domain.Weathers;
using HouseApp.Backend.Infrastructure.Weathers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HouseApp.Backend.Infrastructure.Database.Extensions;

public static class WebApplicationBuilderExtensions
{
    public static void AddDatabase(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<IForecastRepository, ForecastRepository>();
        builder.Services.AddScoped<ILocationRepository, LocationRepository>();
    }
}