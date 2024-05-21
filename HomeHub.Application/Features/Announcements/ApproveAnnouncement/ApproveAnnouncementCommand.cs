using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Announcements.ApproveAnnouncement;

public class ApproveAnnouncementCommand : ICommand
{
    public long AnnouncementId { get; set; }
}