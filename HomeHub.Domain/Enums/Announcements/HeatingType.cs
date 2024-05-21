using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum HeatingTypeEnum
{
    City = 1,
    Gas = 2,
    TiledStoves = 3,
    Electric = 4,
    BoilerRoom = 5,
    Others = 6,
}

public class HeatingTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)HeatingTypeEnum.City, "City"},
        {(long)HeatingTypeEnum.Gas, "Gas"},
        {(long)HeatingTypeEnum.TiledStoves, "TiledStoves"},
        {(long)HeatingTypeEnum.Electric, "Electric"},
        {(long)HeatingTypeEnum.BoilerRoom, "BoilerRoom"},
        {(long)HeatingTypeEnum.Others, "Others"}
    };
}