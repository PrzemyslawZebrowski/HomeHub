using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AdditionalDetailConfiguration : IEntityTypeConfiguration<AdditionalDetail>
{
    public void Configure(EntityTypeBuilder<AdditionalDetail> builder)
    {
        builder.HasKey(d => d.Id);
        builder.ToTable("AdditionalDetail");

        builder.HasOne<DetailsGroup>()
            .WithMany()
            .HasForeignKey(d => d.GroupId);

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<AdditionalDetail> builder)
    {
        foreach (var o in Enum.GetValues(typeof(AdditionalDetailEnum)))
        {
            builder.HasData(new AdditionalDetail((int)o, AdditionalDetailNames.Names[(int)o], AdditionalDetailGroups.Groups[(int)o]));
        }
    }
}