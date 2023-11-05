using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Backend.Light.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "GetTest")]
    public string Get()
    {
        return "Hello Light API World!";
    }
}
