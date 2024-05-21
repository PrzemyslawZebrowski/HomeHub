using HomeHub.Domain.Enums.Announcements;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class AnnouncementSubjectAndTypeForm
{
    public SubjectTypeEnum SubjectTypeId { get; set; }
    public AnnouncementTypeEnum TypeId { get; set; }
}