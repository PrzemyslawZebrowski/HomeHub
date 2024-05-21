using EnsureThat;
using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementPhoto : BaseEntity
{
    private AnnouncementPhoto()
    {
    }

    public AnnouncementPhoto(Announcement announcement, string name, string url, bool isMainPhoto)
    {
        EnsureArg.IsNotNull(announcement, nameof(announcement));

        Announcement = announcement;
        Name = name;
        Url = url;
        IsMainPhoto = isMainPhoto;
    }

    public long AnnouncementId { get; private set; }
    public Announcement Announcement { get; private set; }
    public bool IsMainPhoto { get; private set; }
    public string Name { get; private set; }
    public string Url { get; private set; }

    public void SetIsMainPhoto(bool isMainPhoto) => IsMainPhoto = isMainPhoto;
}