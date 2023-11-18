using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Backend.JobRunner.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "GetSourceName")]
    public string Get()
    {
        return "HouseApp.Backend.JobRunner";
    }
}