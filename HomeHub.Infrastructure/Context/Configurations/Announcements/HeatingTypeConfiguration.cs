using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class HeatingTypeConfiguration : IEntityTypeConfiguration<HeatingType>
{
    public void Configure(EntityTypeBuilder<HeatingType> builder)
    {
        builder.HasKey(h => h.Id);
        builder.ToTable("HeatingType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<HeatingType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(HeatingTypeEnum)))
        {
            builder.HasData(new HeatingType((int)o, HeatingTypeNames.Names[(int)o]));
        }
    }
}