using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class BuildingFinishConditionConfiguration : IEntityTypeConfiguration<BuildingFinishCondition>
{
    public void Configure(EntityTypeBuilder<BuildingFinishCondition> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable("BuildingFinishCondition");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<BuildingFinishCondition> builder)
    {
        foreach (var o in Enum.GetValues(typeof(BuildingFinishConditionEnum)))
        {
            builder.HasData(new BuildingFinishCondition((int)o, BuildingFinishConditionNames.Names[(int)o]));
        }
    }
}