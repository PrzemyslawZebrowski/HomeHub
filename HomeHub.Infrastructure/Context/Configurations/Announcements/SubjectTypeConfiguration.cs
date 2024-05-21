using System;
using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Enums.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class SubjectTypeConfiguration : IEntityTypeConfiguration<SubjectType>
{
    public void Configure(EntityTypeBuilder<SubjectType> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("SubjectType");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<SubjectType> builder)
    {
        foreach (var o in Enum.GetValues(typeof(SubjectTypeEnum)))
        {
            builder.HasData(new SubjectType((int)o, SubjectTypeNames.Names[(int)o]));
        }
    }
}