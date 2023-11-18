using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Backend.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "GetSourceName")]
    public string Get()
    {
        return "HouseApp.Backend.API";
    }
}