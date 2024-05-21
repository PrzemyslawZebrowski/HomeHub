using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum BuildingFinishConditionEnum
{
    ForLiving = 1,
    ForFinishing = 2,
    ForRenovation = 3
}

public class BuildingFinishConditionNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)BuildingFinishConditionEnum.ForLiving, "ForLiving"},
        {(long)BuildingFinishConditionEnum.ForFinishing, "ForFinishing"},
        {(long)BuildingFinishConditionEnum.ForRenovation, "ForRenovation"}
    };
}