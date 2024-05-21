using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AdditionalDetail : BaseLookup
{
    private AdditionalDetail()
    {
    }

    public AdditionalDetail(long id, string name, long groupId) : base(id, name)
    {
        GroupId = groupId;
    }

    public long GroupId { get; private set; }
}