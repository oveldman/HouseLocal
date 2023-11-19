using HouseApp.Backend.Domain.Weathers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseApp.Backend.Infrastructure.Weathers;

public class ForecastEntityTypeConfiguration : IEntityTypeConfiguration<Forecast>
{
    public void Configure(EntityTypeBuilder<Forecast> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Date)
            .IsRequired();

        builder.HasOne<Location>(x => x.Location)
            .WithMany(x => x.Forecasts)
            .HasForeignKey(x => x.LocationId);

        builder.Navigation(x => x.Location).AutoInclude();
    }
}