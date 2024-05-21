using System.Collections.Generic;
using System.Linq;
using EnsureThat;
using HomeHub.Domain.Common;
using HomeHub.Domain.Enums.Announcements;
using HomeHub.Domain.ValueObjects;

namespace HomeHub.Domain.Entities.Announcements;

public class Announcement : BaseEntity
{
    private Announcement()
    {
    }

    public Announcement(SubjectTypeEnum subjectType, AnnouncementTypeEnum announcementType,
        string title, Money price,
        decimal area, int numberOfRooms, MarketTypeEnum marketType,
        AdvertiserTypeEnum advertiserType, AnnouncementContactDetails contactDetails,
        AnnouncementLocalization localization, AnnouncementDetails details, List<long> additionalDetailIds,
        AnnouncementMultimedia multimedia)
    {
        UpdateAnnouncement(
            subjectType,
            announcementType,
            title,
            price,
            area,
            numberOfRooms,
            marketType,
            advertiserType,
            contactDetails,
            localization,
            details,
            additionalDetailIds,
            multimedia);
    }

    public long SubjectTypeId { get; private set; }
    public long TypeId { get; private set; }
    public string Title { get; private set; }
    public Money Price { get; private set; }
    public decimal Area { get; private set; }
    public int NumberOfRooms { get; private set; }
    public long MarketTypeId { get; private set; }
    public long AdvertiserTypeId { get; private set; }
    public long StatusId { get; private set; }
    public AnnouncementContactDetails ContactDetails { get; private set; }
    public AnnouncementLocalization Localization { get; private set; }
    public AnnouncementDetails Details { get; private set; }
    public List<AnnouncementAdditionalDetail> AdditionalDetails { get; private set; } = new();

    public AnnouncementMultimedia Multimedia { get; private set; }
    public List<AnnouncementPhoto> Photos { get; private set; } = new();

    public void UpdateAnnouncement(SubjectTypeEnum subjectType, AnnouncementTypeEnum announcementType, string title,
        Money price, decimal area, int numberOfRooms, MarketTypeEnum marketType, AdvertiserTypeEnum advertiserType,
        AnnouncementContactDetails contactDetails, AnnouncementLocalization localization, AnnouncementDetails details,
        List<long> additionalDetailIds, AnnouncementMultimedia multimedia)
    {
        SubjectTypeId = (long)subjectType;
        TypeId = (long)announcementType;
        Title = title;
        Price = price;
        Area = area;
        NumberOfRooms = numberOfRooms;
        MarketTypeId = (long)marketType;
        AdvertiserTypeId = (long)advertiserType;
        ContactDetails = contactDetails;
        Localization = localization;
        Details = details;
        Multimedia = multimedia;
        StatusId = (long)AnnouncementStatusEnum.Pending;

        if (additionalDetailIds is not null && additionalDetailIds.Any())
        {
            SetAdditionalDetails(additionalDetailIds);
        }
    }

    public void AddPhoto(string fileName, string url, bool isMainPhoto)
    {
        EnsureArg.IsNotNullOrWhiteSpace(fileName, nameof(fileName));
        EnsureArg.IsNotNullOrWhiteSpace(url, nameof(url));

        if (isMainPhoto)
        {
            Photos.ForEach(p => p.SetIsMainPhoto(false));
        }

        Photos.Add(new AnnouncementPhoto(this, fileName, url, isMainPhoto));
    }

    public void RemovePhoto(AnnouncementPhoto photo)
    {
        EnsureArg.IsNotNull(photo, nameof(photo));

        Photos.Remove(photo);
    }

    public void SetMainPhoto(long photoId)
    {
        Photos.ForEach(p => p.SetIsMainPhoto(false));
        Photos.Find(p => p.Id == photoId).SetIsMainPhoto(true);
    }

    private void SetAdditionalDetails(IEnumerable<long> additionalDetailIds)
    {
        AdditionalDetails.Clear();
        AdditionalDetails.AddRange(
            additionalDetailIds
                .Select(id => new AnnouncementAdditionalDetail(this, id)).ToList()
        );
    }

    public void SetStatus(AnnouncementStatusEnum status)
    {
        StatusId = (long)status;
    }
}