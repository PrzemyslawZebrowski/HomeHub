using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class WindowType : BaseLookup
{
    private WindowType()
    {
    }

    public WindowType(long id, string name) : base(id, name)
    {
    }
}