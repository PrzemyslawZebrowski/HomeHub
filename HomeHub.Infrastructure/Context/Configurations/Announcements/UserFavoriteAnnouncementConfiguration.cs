using HomeHub.Domain.Entities.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class UserFavoriteAnnouncementConfiguration : IEntityTypeConfiguration<UserFavoriteAnnouncement>
{
    public void Configure(EntityTypeBuilder<UserFavoriteAnnouncement> builder)
    {
        builder.HasKey(a => new { a.UserId, a.AnnouncementId });

        builder.HasOne(d => d.User)
            .WithMany(u => u.FavoriteAnnouncements)
            .HasForeignKey(d => d.UserId);

        builder.HasOne<Announcement>()
            .WithMany()
            .HasForeignKey(d => d.AnnouncementId);

        builder.ToTable("UserFavoriteAnnouncement");
    }
}