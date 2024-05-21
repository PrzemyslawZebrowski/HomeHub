using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Announcements.AddFavoriteAnnouncement;

public class AddFavoriteAnnouncementCommand : ICommand
{
    public long AnnouncementId { get; set; }
}