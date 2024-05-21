using EnsureThat;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementAdditionalDetail
{
    private AnnouncementAdditionalDetail()
    {
    }

    public AnnouncementAdditionalDetail(Announcement announcement, long additionalDetailId)
    {
        EnsureArg.IsNotNull(announcement);

        Announcement = announcement;
        AdditionalDetailId = additionalDetailId;
    }

    public long AnnouncementId { get; private set; }
    public Announcement Announcement { get; private set; }
    public long AdditionalDetailId { get; private set; }
}