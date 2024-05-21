using System.Collections.Generic;

namespace HomeHub.Application.Features.Announcements.CreateAnnouncement;

public class AnnouncementMultimediaForm
{
    public string VideoUrl { get; set; }
    public string VirtualWalkUrl { get; set; }

    public List<AnnouncementPhotoForm> Photos { get; set; }
}