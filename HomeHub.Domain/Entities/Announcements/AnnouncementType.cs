using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementType : BaseLookup
{
    private AnnouncementType() : base()
    {
    }

    public AnnouncementType(int id, string name) : base(id, name)
    {
    }
}