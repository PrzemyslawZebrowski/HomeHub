using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum FloorEnum
{
    Basement = 1,
    GroundFloor = 2,
    Attic = 3,
    First = 4,
    Second = 5,
    Third = 6,
    Fourth = 7,
    Fifth = 8,
    Sixth = 9,
    Seventh = 10,
    Eighth = 11,
    Ninth = 12,
    Tenth = 13,
    MoreThanTenth = 14
}

public class FloorNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)FloorEnum.Basement, "Basement"},
        {(long)FloorEnum.GroundFloor, "GroundFloor"},
        {(long)FloorEnum.Attic, "Attic"},
        {(long)FloorEnum.First, "First"},
        {(long)FloorEnum.Second, "Second"},
        {(long)FloorEnum.Third, "Third"},
        {(long)FloorEnum.Fourth, "Fourth"},
        {(long)FloorEnum.Fifth, "Fifth"},
        {(long)FloorEnum.Sixth, "Sixth"},
        {(long)FloorEnum.Seventh, "Seventh"},
        {(long)FloorEnum.Eighth, "Eighth"},
        {(long)FloorEnum.Ninth, "Ninth"},
        {(long)FloorEnum.Tenth, "Tenth"},
        {(long)FloorEnum.MoreThanTenth, "MoreThanTenth"}
    };
}