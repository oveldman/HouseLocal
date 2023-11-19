using HouseApp.Backend.Domain.Weathers;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Backend.Infrastructure.Weathers;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
    {
    }
    
    public DbSet<Forecast> Forecasts { get; set; }
    public DbSet<Location> Locations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfiguration(new ForecastEntityTypeConfiguration());
        modelBuilder.ApplyConfiguration(new LocationEntityTypeConfiguration());
    }
}