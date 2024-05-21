using HomeHub.Application.Abstraction.CQRS.Command;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class CreateAnnouncementCommand : ICommand
{
    public AnnouncementSubjectAndTypeForm SubjectType { get; set; }
    public AnnouncementBasicInformationForm BasicInformation { get; set; }
    public AnnouncementContactDetailsForm ContactDetails { get; set; }
    public AnnouncementLocalizationForm Localization { get; set; }
    public AnnouncementDetailsForm Details { get; set; }
    public AnnouncementMultimediaForm Multimedia { get; set; }
}