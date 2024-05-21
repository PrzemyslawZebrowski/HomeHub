using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class OwnershipForm : BaseLookup
{
    private OwnershipForm()
    {
    }

    public OwnershipForm(long id, string name) : base(id, name)
    {
    }
}