using HouseApp.Backend.Application.Weathers;
using HouseApp.Contracts;
using HouseApp.Contracts.Weathers;
using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Backend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class LocationController  : ControllerBase
{
    private readonly AddLocationUseCase _addLocationUseCase;
    private readonly GetLocationsUseCase _getLocationsUseCase;

    public LocationController(AddLocationUseCase addLocationUseCase, GetLocationsUseCase getLocationsUseCase)
    {
        _addLocationUseCase = addLocationUseCase;
        _getLocationsUseCase = getLocationsUseCase;
    }
    
    [HttpPost(Name = "GetAllLocations")]
    public Task<DefaultResponse> Add([FromBody] AddLocationRequest request)
    {
        return _addLocationUseCase.AddLocation(request);
    }
    
    [HttpGet(Name = "GetAllLocations")]
    public Task<GetLocationsResponse> Get()
    {
        return _getLocationsUseCase.GetLocations();
    }
}