using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum BuildingMaterialEnum
{
    Brick = 1,
    Wood = 2,
    HollowBlock = 3,
    ExpandedClay = 4,
    LargeSlab = 5,
    Concrete = 6,
    Silicate = 7,
    Cellular = 8,
    ReinforcedConcrete = 9,
    Other = 10
}

public class BuildingMaterialNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)BuildingMaterialEnum.Brick, "Brick"},
        {(long)BuildingMaterialEnum.Wood, "Wood"},
        {(long)BuildingMaterialEnum.HollowBlock, "HollowBlock"},
        {(long)BuildingMaterialEnum.ExpandedClay, "ExpandedClay"},
        {(long)BuildingMaterialEnum.LargeSlab, "LargeSlab"},
        {(long)BuildingMaterialEnum.Concrete, "Concrete"},
        {(long)BuildingMaterialEnum.Silicate, "Silicate"},
        {(long)BuildingMaterialEnum.Cellular, "Cellular"},
        {(long)BuildingMaterialEnum.ReinforcedConcrete, "ReinforcedConcrete"},
        {(long)BuildingMaterialEnum.Other, "Other"}
    };
}