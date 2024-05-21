using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Announcements.CloseAnnouncement;

public class CloseAnnouncementCommand : ICommand
{
    public long AnnouncementId { get; set; }
}