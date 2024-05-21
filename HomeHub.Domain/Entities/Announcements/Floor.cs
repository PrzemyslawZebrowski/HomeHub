using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class Floor : BaseLookup
{
    private Floor()
    {
    }

    public Floor(long id, string name) : base(id, name)
    {
    }
}