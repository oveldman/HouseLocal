using Microsoft.EntityFrameworkCore;

namespace HouseApp.Backend.FormulaOne.Infrastructure.Database;

public class FormulaOneContext : DbContext
{
    public FormulaOneContext(DbContextOptions<FormulaOneContext> options)
        : base(options)
    { }
    
    public DbSet<Driver> Drivers { get; set; } = null!;
}