using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class MarketType : BaseLookup
{
    private MarketType() : base()
    {
    }

    public MarketType(int id, string name) : base(id, name)
    {
    }
}