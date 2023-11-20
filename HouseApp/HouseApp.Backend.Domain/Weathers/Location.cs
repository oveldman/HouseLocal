namespace HouseApp.Backend.Domain.Weathers;

public class Location
{
    public const int MaxLength = 150;
    
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    
    public virtual ICollection<Forecast> Forecasts { get; private set; }
    
    public Location(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(name));
        }
        
        if (name.Length > MaxLength)
        {
            throw new ArgumentException($"Value cannot be longer than {MaxLength} characters.", nameof(name));
        }
        
        Id = Guid.NewGuid();
        Name = name;
        Forecasts = new List<Forecast>();
    }
    
    private Location()
    {
    }
}