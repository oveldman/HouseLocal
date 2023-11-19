namespace HouseApp.Backend.Domain.Weathers;

public interface ILocationRepository
{
    Task<Location> Retrieve(Guid id);
    Task<IEnumerable<Location>> RetrieveAll();
    Task<Location> SaveAsync(Location location);
}