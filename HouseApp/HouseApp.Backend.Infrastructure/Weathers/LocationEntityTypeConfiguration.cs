using HouseApp.Backend.Domain.Weathers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseApp.Backend.Infrastructure.Weathers;

public class LocationEntityTypeConfiguration  : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(Location.MaxLength);

        builder.HasMany<Forecast>().WithOne();
    }
}