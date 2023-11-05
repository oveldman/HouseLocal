using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Backend.Weather.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "GetTest")]
    public string Get()
    {
        return "Hello Weather API World!";
    }
}