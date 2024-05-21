using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class WindowTypeConfiguration : IEntityTypeConfiguration<WindowType>
{
    public void Configure(EntityTypeBuilder<WindowType> builder)
    {
        builder.HasKey(w => w.Id);
        builder.ToTable("WindowType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<WindowType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(WindowTypeEnum)))
        {
            builder.HasData(new WindowType((int)o, WindowTypeNames.Names[(int)o]));
        }
    }
}