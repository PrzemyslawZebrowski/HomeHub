using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum AnnouncementStatusEnum
{
    Pending = 1,
    Approved = 2,
    Refused = 3,
    Closed = 4
}

public class AnnouncementStatusNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)AnnouncementStatusEnum.Pending, "Pending"},
        {(long)AnnouncementStatusEnum.Approved, "Approved"},
        {(long)AnnouncementStatusEnum.Refused, "Refused"},
        {(long)AnnouncementStatusEnum.Closed, "Closed"}
    };
}