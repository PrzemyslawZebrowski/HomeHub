using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class DetailsGroupConfiguration : IEntityTypeConfiguration<DetailsGroup>
{
    public void Configure(EntityTypeBuilder<DetailsGroup> builder)
    {
        builder.HasKey(g => g.Id);
        builder.ToTable("DetailsGroup");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<DetailsGroup> builder)
    {
        foreach (var o in Enum.GetValues(typeof(DetailsGroupEnum)))
        {
            builder.HasData(new DetailsGroup((int)o, DetailsGroupNames.Names[(int)o]));
        }
    }
}