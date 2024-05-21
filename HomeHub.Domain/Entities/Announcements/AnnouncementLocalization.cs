using System.Collections.Generic;
using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementLocalization : ValueObject
{
    private AnnouncementLocalization()
    {
    }

    public AnnouncementLocalization(string address, decimal latitude, decimal longitude)
    {
        Address = address;
        Latitude = latitude;
        Longitude = longitude;
    }

    public string Address { get; private set; }
    public decimal Latitude { get; private set; }
    public decimal Longitude { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Address;
        yield return Latitude;
        yield return Longitude;
    }
}