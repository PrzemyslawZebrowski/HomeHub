using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class DevelopmentTypeConfiguration : IEntityTypeConfiguration<DevelopmentType>
{
    public void Configure(EntityTypeBuilder<DevelopmentType> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("DevelopmentType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<DevelopmentType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(DevelopmentTypeEnum)))
        {
            builder.HasData(new DevelopmentType((int)o, DevelopmentTypeNames.Names[(int)o]));
        }
    }
}