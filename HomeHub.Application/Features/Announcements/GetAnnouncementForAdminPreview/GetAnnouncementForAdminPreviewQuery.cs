using HomeHub.Application.Abstraction.CQRS.Query;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementForAdminPreview;

public class GetAnnouncementForAdminPreviewQuery : IQuery<AnnouncementForAdminPreviewDTO>
{
    public long AnnouncementId { get; set; }
}