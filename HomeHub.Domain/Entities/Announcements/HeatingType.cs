using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class HeatingType : BaseLookup
{
    private HeatingType()
    {
    }

    public HeatingType(long id, string name) : base(id, name)
    {
    }
}