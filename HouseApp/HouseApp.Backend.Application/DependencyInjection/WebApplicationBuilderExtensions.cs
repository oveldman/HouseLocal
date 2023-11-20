using HouseApp.Backend.Application.Weathers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace HouseApp.Backend.Application.DependencyInjection;

public static class WebApplicationBuilderExtensions
{
    public static void AddApplication(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<AddLocationUseCase>();
        builder.Services.AddScoped<GetLocationsUseCase>();
    }
}