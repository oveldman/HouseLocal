using HouseApp.Backend.FormulaOne.Extensions;
using HouseApp.Backend.FormulaOne.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FormulaOneContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("FormulaOneContext")));

builder.AddBackgroundJobs();

var app = builder.Build();

app.UsePathBase(new PathString("/FormulaOne"));
app.UseRouting();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase<FormulaOneContext>();

app.Run();