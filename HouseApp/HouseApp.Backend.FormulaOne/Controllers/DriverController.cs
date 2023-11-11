using HouseApp.Backend.FormulaOne.Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseApp.Backend.FormulaOne.Controllers;

[ApiController]
[Route("[controller]")]
public class DriverController : ControllerBase
{
    private readonly FormulaOneContext _context;

    public DriverController(FormulaOneContext context)
    {
        _context = context;
    }
    
    [HttpGet(Name = "Driver")]
    public List<Driver> Get()
    {
        try
        {
            return _context.Drivers.ToList();
        }
        catch (Exception ex)
        {
            return new List<Driver>()
            {
                new Driver()
                {
                    Id = 0,
                    FullName = ex.Message
                },
                new Driver()
                {
                    Id = 1,
                    FullName = _context.Database.GetConnectionString()!
                }
            };
        }
    }
}