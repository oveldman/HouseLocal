namespace HouseApp.Backend.Domain.Weathers;

public interface IForecastRepository
{
    Task<Forecast> Retrieve(Guid id);
    Task<IEnumerable<Forecast>> RetrieveAll();
    Task<Forecast> SaveAsync(Forecast location);
}