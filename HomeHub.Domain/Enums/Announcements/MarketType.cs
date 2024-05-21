using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum MarketTypeEnum
{
    Primary = 1,
    AfterMarket = 2
}

public class MarketTypeNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        {(long)MarketTypeEnum.Primary, "Primary"},
        {(long)MarketTypeEnum.AfterMarket, "AfterMarket"},
    };
}