using HouseApp.Backend.Application.Weathers.Mappers;
using HouseApp.Backend.Domain.Application;
using HouseApp.Backend.Domain.Weathers;
using HouseApp.Contracts.Weathers;

namespace HouseApp.Backend.Application.Weathers;

public class GetLocationsUseCase : IUseCase
{
    private readonly ILocationRepository _locationRepository;

    public GetLocationsUseCase(ILocationRepository locationRepository)
    {
        _locationRepository = locationRepository;
    }
    
    public async Task<GetLocationsResponse> GetLocations()
    {
        var locations = await _locationRepository.RetrieveAll();
        return new GetLocationsResponse()
        {
            Locations = locations.ToDto()
        };
    }
}