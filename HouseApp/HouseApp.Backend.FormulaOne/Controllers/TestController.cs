using Microsoft.AspNetCore.Mvc;

namespace HouseApp.Backend.FormulaOne.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "GetTest")]
    public string Get()
    {
        return "Hello FormulaOne API World!";
    }
}
