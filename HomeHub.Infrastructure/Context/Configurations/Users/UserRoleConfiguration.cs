using System;
using HomeHub.Domain.Entities.Users;
using HomeHub.Domain.Enums.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Users;

public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasKey(r => r.Id);
        builder.ToTable("UserRole");

        SeedData(builder);
    }

    private static void SeedData(EntityTypeBuilder<UserRole> builder)
    {
        foreach (var o in Enum.GetValues(typeof(UserRoleEnum)))
        {
            builder.HasData(new UserRole((int)o, UserRoleNames.Names[(int)o]));
        }
    }
}