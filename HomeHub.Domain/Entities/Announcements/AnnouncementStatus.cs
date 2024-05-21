using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementStatus : BaseLookup
{
    private AnnouncementStatus() : base()
    {
    }

    public AnnouncementStatus(int id, string name) : base(id, name)
    {
    }
}