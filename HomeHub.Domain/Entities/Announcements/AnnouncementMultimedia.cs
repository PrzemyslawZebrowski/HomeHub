using System.Collections.Generic;
using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementMultimedia : ValueObject
{
    private AnnouncementMultimedia()
    {
    }

    public AnnouncementMultimedia(string videoUrl, string virtualWalkUrl)
    {
        VideoUrl = videoUrl;
        VirtualWalkUrl = virtualWalkUrl;
    }

    public string VideoUrl { get; set; }
    public string VirtualWalkUrl { get; set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return VideoUrl;
        yield return VirtualWalkUrl;
    }
}