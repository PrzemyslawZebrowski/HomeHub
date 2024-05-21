using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class SubjectType : BaseLookup
{
    private SubjectType() : base()
    {
    }

    public SubjectType(int id, string name) : base(id, name)
    {
    }
}