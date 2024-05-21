using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Announcements.RefuseAnnouncement;

public class RefuseAnnouncementCommand : ICommand
{
    public long AnnouncementId { get; set; }
}