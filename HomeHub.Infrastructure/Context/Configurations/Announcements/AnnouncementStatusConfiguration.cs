using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AnnouncementStatusConfiguration : IEntityTypeConfiguration<AnnouncementStatus>
{
    public void Configure(EntityTypeBuilder<AnnouncementStatus> builder)
    {
        builder.HasKey(status => status.Id);
        builder.ToTable("AnnouncementStatus");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<AnnouncementStatus> builder)
    {
        foreach (var o in Enum.GetValues(typeof(AnnouncementStatusEnum)))
        {
            builder.HasData(new AnnouncementStatus((int)o, AnnouncementStatusNames.Names[(int)o]));
        }
    }
}