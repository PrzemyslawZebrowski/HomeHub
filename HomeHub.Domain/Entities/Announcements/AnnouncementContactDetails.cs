using System.Collections.Generic;
using HomeHub.Domain.Common;

namespace HomeHub.Domain.Entities.Announcements;

public class AnnouncementContactDetails : ValueObject
{
    private AnnouncementContactDetails() { }

    public AnnouncementContactDetails(string name, string email, string phoneNumber)
    {
        AdvertiserName = name;
        AdvertiserEmail = email;
        AdvertiserPhoneNumber = phoneNumber;
    }

    public string AdvertiserName { get; private set; }
    public string AdvertiserEmail { get; private set; }
    public string AdvertiserPhoneNumber { get; private set; }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return AdvertiserName;
        yield return AdvertiserEmail;
        yield return AdvertiserPhoneNumber;
    }
}

