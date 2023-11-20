using HouseApp.Backend.Domain.Application;
using HouseApp.Backend.Domain.Weathers;
using HouseApp.Contracts;
using HouseApp.Contracts.Weathers;

namespace HouseApp.Backend.Application.Weathers;

public class AddLocationUseCase : IUseCase
{
    private readonly ILocationRepository _repository;

    public AddLocationUseCase(ILocationRepository repository)
    {
        _repository = repository;
    }
    public async Task<DefaultResponse> AddLocation(AddLocationRequest request)
    {
        ArgumentNullException.ThrowIfNull(request);

        var location = new Location(request.Name);
        await _repository.SaveAsync(location);
        
        return DefaultResponse.Succeed;
    }
}