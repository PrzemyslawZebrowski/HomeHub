using HomeHub.Domain.Entities.Announcements;
using HomeHub.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Users;

public class AnnouncementConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(u => u.Id);
        builder.ToTable("User");

        builder.HasOne<UserRole>()
            .WithMany()
            .HasForeignKey(u => u.RoleId);

        builder.HasOne<AdvertiserType>()
            .WithMany()
            .HasForeignKey(u => u.AdvertiserTypeId);
    }
}