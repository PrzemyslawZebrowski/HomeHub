using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AdvertiserType : BaseLookup
{
    private AdvertiserType() : base()
    {
    }

    public AdvertiserType(int id, string name) : base(id, name)
    {
    }
}