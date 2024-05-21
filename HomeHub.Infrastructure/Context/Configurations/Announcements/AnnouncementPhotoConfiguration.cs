using HomeHub.Domain.Entities.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AnnouncementPhotoConfiguration : IEntityTypeConfiguration<AnnouncementPhoto>
{
    public void Configure(EntityTypeBuilder<AnnouncementPhoto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.ToTable("AnnouncementPhoto");
    }
}