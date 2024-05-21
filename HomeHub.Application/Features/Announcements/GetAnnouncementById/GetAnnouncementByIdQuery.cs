using HomeHub.Application.Abstraction.CQRS.Query;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementById;

public class GetAnnouncementByIdQuery : IQuery<AnnouncementDTO>
{
    public long AnnouncementId { get; set; }
}