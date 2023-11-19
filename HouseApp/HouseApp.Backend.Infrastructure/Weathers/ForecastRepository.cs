using HouseApp.Backend.Domain.Weathers;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Backend.Infrastructure.Weathers;

public class ForecastRepository : IForecastRepository
{
    private readonly WeatherDbContext _context;

    public ForecastRepository(WeatherDbContext context)
    {
        _context = context;
    }

    public async Task<Forecast> Retrieve(Guid id)
    {
        return await _context.Forecasts
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Forecast>> RetrieveAll()
    {
        return await _context.Forecasts
            .ToListAsync();
    }

    public async Task<Forecast> SaveAsync(Forecast location)
    {
        await _context.Forecasts.AddAsync(location);
        await _context.SaveChangesAsync();

        return location;
    }
}