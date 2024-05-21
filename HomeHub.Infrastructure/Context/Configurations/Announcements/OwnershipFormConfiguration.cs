using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class OwnershipFormConfiguration : IEntityTypeConfiguration<OwnershipForm>
{
    public void Configure(EntityTypeBuilder<OwnershipForm> builder)
    {
        builder.HasKey(o => o.Id);
        builder.ToTable("OwnershipForm");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<OwnershipForm> builder)
    {
        foreach (var o in Enum.GetValues(typeof(OwnershipFormEnum)))
        {
            builder.HasData(new OwnershipForm((int)o, OwnershipFormNames.Names[(int)o]));
        }
    }
}