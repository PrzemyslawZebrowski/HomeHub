using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class FloorConfiguration : IEntityTypeConfiguration<Floor>
{
    public void Configure(EntityTypeBuilder<Floor> builder)
    {
        builder.HasKey(f => f.Id);
        builder.ToTable("Floor");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<Floor> builder)
    {
        foreach (var o in Enum.GetValues(typeof(FloorEnum)))
        {
            builder.HasData(new Floor((int)o, FloorNames.Names[(int)o]));
        }
    }
}