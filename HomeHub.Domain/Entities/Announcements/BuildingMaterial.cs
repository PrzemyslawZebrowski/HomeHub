using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class BuildingMaterial : BaseLookup
{
    private BuildingMaterial()
    {
    }

    public BuildingMaterial(long id, string name) : base(id, name)
    {
    }
}