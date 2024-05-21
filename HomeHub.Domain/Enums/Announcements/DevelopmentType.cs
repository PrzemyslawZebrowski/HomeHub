using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum DevelopmentTypeEnum
{
    BlockOfFlats = 1,
    TenementHouse = 2,
    DetachedHouse = 3,
    Infill = 4,
    TerracedHouse = 5,
    ApartmentBuilding = 6,
    Loft = 7
}

public class DevelopmentTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)DevelopmentTypeEnum.BlockOfFlats, "BlockOfFlats"},
        {(long)DevelopmentTypeEnum.TenementHouse, "TenementHouse"},
        {(long)DevelopmentTypeEnum.DetachedHouse, "DetachedHouse"},
        {(long)DevelopmentTypeEnum.Infill, "Infill"},
        {(long)DevelopmentTypeEnum.TerracedHouse, "TerracedHouse"},
        {(long)DevelopmentTypeEnum.ApartmentBuilding, "ApartmentBuilding"},
        {(long)DevelopmentTypeEnum.Loft, "Loft"}
    };
}