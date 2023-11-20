using HouseApp.Backend.Application.DependencyInjection;
using HouseApp.Backend.Infrastructure.Database.Extensions;
using HouseApp.Backend.Infrastructure.Weathers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddApplication();
builder.AddDatabase();

builder.Services.AddDbContext<WeatherDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString(nameof(WeatherDbContext)),
        b => b.MigrationsAssembly("HouseApp.Backend.Infrastructure")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase<WeatherDbContext>();

app.Run();