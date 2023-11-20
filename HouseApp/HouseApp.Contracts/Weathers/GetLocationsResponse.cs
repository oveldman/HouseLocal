namespace HouseApp.Contracts.Weathers;

public class GetLocationsResponse
{
    public IReadOnlyList<LocationContract> Locations { get; set; } = Array.Empty<LocationContract>();
}