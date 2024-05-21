using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Announcements.RemoveFavoriteAnnouncement;

public class RemoveFavoriteAnnouncementCommand : ICommand
{
    public long AnnouncementId { get; set; }
}