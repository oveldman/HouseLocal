using System.ComponentModel.DataAnnotations;

namespace HouseApp.Backend.FormulaOne.Infrastructure.Database;

public class Driver
{
    [Key]
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int CarNumber { get; set; }
}