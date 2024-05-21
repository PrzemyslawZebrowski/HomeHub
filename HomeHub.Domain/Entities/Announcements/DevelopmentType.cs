using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class DevelopmentType : BaseLookup
{
    private DevelopmentType()
    {
    }

    public DevelopmentType(long id, string name) : base(id, name)
    {
    }
}