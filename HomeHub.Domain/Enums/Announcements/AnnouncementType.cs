using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum AnnouncementTypeEnum
{
    Sale = 1,
    Rent = 2
}

public class AnnouncementTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)AnnouncementTypeEnum.Sale, "Sale"},
        {(long)AnnouncementTypeEnum.Rent, "Rent"},
    };
}