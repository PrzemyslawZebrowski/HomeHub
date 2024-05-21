using Microsoft.AspNetCore.Http;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class AnnouncementPhotoForm
{
    public long Id { get; set; }
    public IFormFile File { get; set; }
    public bool IsMainPhoto { get; set; }
}