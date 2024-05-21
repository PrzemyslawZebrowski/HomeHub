using HomeHub.Application.Features.Announcements.CreateAnnouncement;

namespace HomeHub.Application.Features.Announcements.UpdateAnnouncement;

public class UpdateAnnouncementCommand : CreateAnnouncementCommand
{
    public long AnnouncementId { get; set; }
}