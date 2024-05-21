using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum WindowTypeEnum
{
    Plastic = 1,
    Aluminum = 2,
    Wooden = 3
}

public class WindowTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)WindowTypeEnum.Plastic, "Plastic"},
        {(long)WindowTypeEnum.Aluminum, "Aluminum"},
        {(long)WindowTypeEnum.Wooden, "Wooden"}
    };
}