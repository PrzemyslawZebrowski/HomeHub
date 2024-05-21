using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AnnouncementTypeConfiguration : IEntityTypeConfiguration<AnnouncementType>
{
    public void Configure(EntityTypeBuilder<AnnouncementType> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("AnnouncementType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<AnnouncementType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(AnnouncementTypeEnum)))
        {
            builder.HasData(new AnnouncementType((int)o, AnnouncementTypeNames.Names[(int)o]));
        }
    }
}