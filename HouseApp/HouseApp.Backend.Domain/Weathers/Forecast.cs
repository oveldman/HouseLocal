namespace HouseApp.Backend.Domain.Weathers;

public class Forecast
{
    public Guid Id { get; private set; }
    public int CelsiusTemperature { get; private set; }
    public DateTime Date { get; private set; }
    
    public Guid LocationId { get; private set; }
    public Location Location { get; private set; }

    public Forecast(int celsiusTemperature, DateTime date, Location location)
    {
        Id = Guid.NewGuid();
        CelsiusTemperature = celsiusTemperature;
        Date = date;
        LocationId = location.Id;
        Location = location;
    }
    
    private Forecast()
    {
    }
}