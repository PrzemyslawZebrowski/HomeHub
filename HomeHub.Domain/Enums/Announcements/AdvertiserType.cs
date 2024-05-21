using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum AdvertiserTypeEnum
{
    Owner = 1,
    Broker = 2
}

public class AdvertiserTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)AdvertiserTypeEnum.Owner, "Owner"},
        {(long)AdvertiserTypeEnum.Broker, "Broker"},
    };
}