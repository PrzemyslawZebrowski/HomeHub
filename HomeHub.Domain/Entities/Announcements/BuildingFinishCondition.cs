using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class BuildingFinishCondition : BaseLookup
{
    private BuildingFinishCondition()
    {
    }

    public BuildingFinishCondition(long id, string name) : base(id, name)
    {
    }
}