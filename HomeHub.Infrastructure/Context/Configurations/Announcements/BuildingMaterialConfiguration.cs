using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class BuildingMaterialConfiguration : IEntityTypeConfiguration<BuildingMaterial>
{
    public void Configure(EntityTypeBuilder<BuildingMaterial> builder)
    {
        builder.HasKey(b => b.Id);
        builder.ToTable("BuildingMaterial");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<BuildingMaterial> builder)
    {
        foreach (var o in Enum.GetValues(typeof(BuildingMaterialEnum)))
        {
            builder.HasData(new BuildingMaterial((int)o, BuildingMaterialNames.Names[(int)o]));
        }
    }
}