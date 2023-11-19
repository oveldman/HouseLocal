using HouseApp.Backend.Domain.Weathers;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Backend.Infrastructure.Weathers;

public class LocationRepository : ILocationRepository
{
    private readonly WeatherDbContext _context;

    public LocationRepository(WeatherDbContext context)
    {
        _context = context;
    }

    public async Task<Location> Retrieve(Guid id)
    {
        return await _context.Locations
            .SingleOrDefaultAsync(x => x.Id == id);
    }

    public async Task<IEnumerable<Location>> RetrieveAll()
    {
        return await _context.Locations
            .ToListAsync();
    }

    public async Task<Location> SaveAsync(Location location)
    {
        await _context.Locations.AddAsync(location);
        await _context.SaveChangesAsync();

        return location;
    }
}