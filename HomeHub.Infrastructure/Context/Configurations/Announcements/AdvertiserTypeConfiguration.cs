using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AdvertiserTypeConfiguration : IEntityTypeConfiguration<AdvertiserType>
{
    public void Configure(EntityTypeBuilder<AdvertiserType> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("AdvertiserType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<AdvertiserType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(AdvertiserTypeEnum)))
        {
            builder.HasData(new AdvertiserType((int)o, AdvertiserTypeNames.Names[(int)o]));
        }
    }
}