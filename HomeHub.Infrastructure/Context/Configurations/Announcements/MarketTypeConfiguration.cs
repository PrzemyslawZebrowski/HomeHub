using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class MarketTypeConfiguration : IEntityTypeConfiguration<MarketType>
{
    public void Configure(EntityTypeBuilder<MarketType> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("MarketType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<MarketType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(MarketTypeEnum)))
        {
            builder.HasData(new MarketType((int)o, MarketTypeNames.Names[(int)o]));
        }
    }
}