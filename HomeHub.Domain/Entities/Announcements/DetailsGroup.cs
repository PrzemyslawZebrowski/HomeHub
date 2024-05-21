using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class DetailsGroup : BaseLookup
{
    private DetailsGroup()
    {
    }

    public DetailsGroup(int id, string name) : base(id, name)
    {
    }
}