using HouseApp.Backend.Domain.Weathers;
using HouseApp.Contracts.Weathers;

namespace HouseApp.Backend.Application.Weathers.Mappers;

public static class LocationMapper
{
    public static IReadOnlyList<LocationContract> ToDto(this IEnumerable<Location> locations)
    {
        return locations
                .Select(ToLocationContract)
                .ToList();
    }
    
    private static LocationContract ToLocationContract(Location location)
    {
        return new LocationContract()
        {
            Id = location.Id,
            Name = location.Name
        };
    }
}