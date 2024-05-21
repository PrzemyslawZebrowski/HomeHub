using HomeHub.Application.Features.Announcements.GetAnnouncementForProfile;
using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.GetAnnouncementForAdminPreview;

public class AnnouncementForAdminPreviewDTO : AnnouncementForProfileDTO
{
    public AnnouncementStatusEnum StatusId { get; set; }
    public string StatusName { get; set; }
}