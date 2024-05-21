using HomeHub.Application.Abstraction.CQRS.Query;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;

public class GetAnnouncementForProfileQuery : IQuery<AnnouncementForProfileDTO>
{
    public long AnnouncementId { get; set; }
}