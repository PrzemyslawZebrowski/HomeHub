using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum SubjectTypeEnum
{
    Apartment = 1,
    House = 2
}

public class SubjectTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)SubjectTypeEnum.Apartment, "Apartment"},
        {(long)SubjectTypeEnum.House, "House"}
    };
}