using HomeHub.Domain.Entities.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeHub.Infrastructure.Context.Configurations.Announcements;

public class AnnouncementAdditionalDetailConfiguration : IEntityTypeConfiguration<AnnouncementAdditionalDetail>
{
    public void Configure(EntityTypeBuilder<AnnouncementAdditionalDetail> builder)
    {
        builder.HasKey(d => new { d.AnnouncementId, d.AdditionalDetailId });

        builder.HasOne(d => d.Announcement)
            .WithMany(a => a.AdditionalDetails)
            .HasForeignKey(d => d.AnnouncementId);

        builder.HasOne<AdditionalDetail>()
            .WithMany()
            .HasForeignKey(d => d.AdditionalDetailId);

        builder.ToTable("AnnouncementAdditionalDetail");
    }
}